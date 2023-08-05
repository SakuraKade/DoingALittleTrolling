using DoingABitOfTrolling.JokeEvents.Forms;
using System;
using System.Linq;

namespace DoingABitOfTrolling.JokeEvents
{
    internal class PopCatEvent : JokeEvent
    {
        public override int Weight => 50;

        public override string Name => "Popcat";

        public override string Description => "POPCAT!";

        public override float MinDurationSeconds => 3;

        public override float MaxDurationSeconds => 3;

        public override float TicksPerSecond => 1;

        private PopCat popCat;

        protected override void Setup()
        {
            popCat = new PopCat();
            popCat.Show();
        }

        protected override void Teardown()
        {
            popCat.Stop();
            popCat.Close();
            popCat.Dispose();
        }

        protected override void Update()
        {

        }
    }
}
