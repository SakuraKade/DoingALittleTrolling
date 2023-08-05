using System;
using System.Linq;

namespace DoingABitOfTrolling.JokeEvents
{
    internal abstract class JokeEvent
    {
        [Obsolete]
        public abstract int Weight { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract float MinDurationSeconds { get; }
        public abstract float MaxDurationSeconds { get; }
        public abstract float TicksPerSecond { get; }

        private bool ended = false;

        public async Task Run()
        {
            ended = false;

            Random random = new Random();
            float multiplier = (float)random.NextDouble();
            float duration = MaxDurationSeconds * multiplier;
            duration = Math.Max(duration, MinDurationSeconds);
            int durationMs = (int)(duration * 1000);
            int millisecondsBetweenTicks = (int)(1000 / TicksPerSecond);

            Setup();

            for (int i = 0; i < durationMs; i += millisecondsBetweenTicks)
            {
                Update();
                if (ended) break;
                await Task.Delay(millisecondsBetweenTicks).ConfigureAwait(true);
            }

            Teardown();
        }

        protected abstract void Setup();

        protected abstract void Update();

        protected abstract void Teardown();

        protected void End()
        {
            ended = true;
        }
    }
}
