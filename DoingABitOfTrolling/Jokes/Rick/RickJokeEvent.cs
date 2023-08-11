using DoingABitOfTrolling.Jokes.Rick.Resources;
using DoingABitOfTrolling.Lib.Abstacts;
using DoingABitOfTrolling.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace DoingABitOfTrolling.Jokes.Rick
{
    internal class RickJokeEvent : IJokeEvent
    {
        // Resources

        EmbededResource<IDisposableList<Bitmap>> rickFrames = new EmbededRickFrames();
        EmbededResource<UnmanagedMemoryStream>  embeddedRickRollAudioStream = new EmbededRickAudio();

        // end of Resources

        // Runtime disposables

        Lazy<SoundPlayer> soundPlayer;

        // end of Runtime disposables

        public RickJokeEvent()
        {
            soundPlayer = new Lazy<SoundPlayer>(new SoundPlayer(embeddedRickRollAudioStream.GetValue()));
        }

        public string Name => "Rick";

        public string Description => "";

        public float TicksPerSecound => 1;

        public float MaxDurationInSecound => 30;

        public float MinDurationInSecound => 10;

        public void Dispose()
        {
            if (soundPlayer.IsValueCreated) 
                soundPlayer.Value.Dispose();

            rickFrames.Dispose();
            embeddedRickRollAudioStream.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SetupAsync(CancellationToken cancellationToken)
        {
            using Task task = Task.Run(() => soundPlayer.Value.LoadAsync());
            task.Wait(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
        }

        public async Task TeardownAsync(CancellationToken cancellationToken)
        {
            if(soundPlayer.IsValueCreated) soundPlayer.Value.Stop();
        }

        public async Task TickAsync(CancellationToken cancellationToken)
        {
            
        }
    }
}
