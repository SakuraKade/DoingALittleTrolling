using DoingABitOfTrolling.JokeEvents;
using DoingABitOfTrolling.JokeEvents.Forms;

namespace DoingABitOfTrolling
{
    internal class RickEvent : JokeEvent
    {
        public override int Weight => 0;

        public override string Name => "Knock, knock. It's Rick.";

        public override string Description => string.Empty;

        public override float MinDurationSeconds => 20;

        public override float MaxDurationSeconds => 230;

        public override float TicksPerSecond => 1;

        private Rick? rick;

        protected override void Setup()
        {
            rick = new Rick();
            rick.Show();
        }

        protected override void Teardown()
        {
            if (rick == null) return;

            rick.Stop();
            rick.Close();
            rick.Dispose();
            rick = null;
        }

        protected override void Update()
        {

        }
    }
}