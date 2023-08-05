using DoingABitOfTrolling.JokeEvents.Forms;
using System;
using System.Linq;

namespace DoingABitOfTrolling.JokeEvents
{
    internal class ErrorsMuchEvent : JokeEvent
    {
        public override int Weight => 0;

        public override string Name => "Errors, Much???";

        public override string Description => "Why so many errors?";

        public override float MinDurationSeconds => 2;

        public override float MaxDurationSeconds => 3;

        public override float TicksPerSecond => 50;

        private List<ErrorsMuch> errorsMuches = new List<ErrorsMuch>();

        protected override void Setup()
        {

        }

        protected override void Teardown()
        {
            foreach (ErrorsMuch error in errorsMuches)
            {
                error.CustomDispose();
                error?.Dispose();
            }

            GC.SuppressFinalize(this);
            errorsMuches.Clear();
            GC.Collect();
        }

        protected override void Update()
        {
            ErrorsMuch errorsMuch = new ErrorsMuch();
            errorsMuch.Show();
            errorsMuches.Add(errorsMuch);
        }
    }
}
