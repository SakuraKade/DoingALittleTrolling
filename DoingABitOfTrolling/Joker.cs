using DoingABitOfTrolling.JokeEvents;

namespace DoingABitOfTrolling
{
    internal class Joker
    {
        internal async Task RunAsync(CancellationToken token)
        {
            Extentions.Random random = new Extentions.Random();

            const float minTimeBetweenPunishmentsInSeconds = 10;
            const float maxTimeBetweenPunishmentsInSeconds = 7200; // 7200 two hours
            JokeHat jokeHat = new JokeHat();
            jokeHat.Add(new PopCatEvent());
            jokeHat.Add(new RickEvent());
            jokeHat.Add(new ErrorsMuchEvent());

            PunishmentOverlay overlay;

            while (true)
            {
                if (token.IsCancellationRequested) break;
                overlay = new PunishmentOverlay();
                float secondsToNextPunishment = random.NextFloat(minTimeBetweenPunishmentsInSeconds, maxTimeBetweenPunishmentsInSeconds);
                await Task.Delay((int)(secondsToNextPunishment * 1000), token).ConfigureAwait(true);
                if (token.IsCancellationRequested) break;
                JokeEvent randomJoke = jokeHat.GetRandom();

                overlay.SetJokeName(randomJoke.Name);
                overlay.Show();

                await Task.Delay(2500, token).ConfigureAwait(true); // Wait two and a half sec
                if (token.IsCancellationRequested) break;

                await randomJoke.Run().ConfigureAwait(true);
                overlay.Close();
                overlay.Dispose();
            }
        }
    }
}
