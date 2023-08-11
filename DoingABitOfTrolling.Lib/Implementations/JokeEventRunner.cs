using DoingABitOfTrolling.Lib.Interfaces;
using System;
using System.Linq;

namespace DoingABitOfTrolling.Lib.Implementations
{
    public class JokeEventRunner : IJokeEventRunner
    {
        public async Task RunAsync(IJokeEvent jokeEvent, CancellationToken cancellationToken)
        {
            Random random = new Random();
            int minDuration = (int)(jokeEvent.MinDurationInSecound * 1000);
            int maxDuration = (int)(jokeEvent.MaxDurationInSecound * 1000);
            int duration = random.Next(minDuration, maxDuration);
            int timeBetweenTicks = (int)MathF.Ceiling(1 / jokeEvent.TicksPerSecound);

            await jokeEvent.SetupAsync(cancellationToken);

            int elapsedTime = 0;
            while (elapsedTime < duration)
            {
                if (cancellationToken.IsCancellationRequested)
                    return;

                await Task.Delay(timeBetweenTicks);
                elapsedTime += timeBetweenTicks;

                await jokeEvent.TickAsync(cancellationToken);
            }

            await jokeEvent.TeardownAsync(cancellationToken);
        }
    }
}
