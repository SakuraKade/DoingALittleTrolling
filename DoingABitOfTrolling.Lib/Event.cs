using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingABitOfTrolling.Lib
{
    public abstract class Event
    {
        public abstract string Name { get; }
        public abstract int MinDuration { get; }
        public abstract int MaxDuration { get; }
        protected abstract int targetDeltaTime { get; }

        public void Run(int duration)
        {
            try
            {
                Setup();
                TickLoop(duration);
                Teardown();
            }
            catch (Exception e)
            {
                // TODO: Logging
            }
        }

        /// <summary>
        /// Put your setup code here
        /// </summary>
        protected virtual void Setup()
        {

        }

        private void TickLoop(int duration)
        {
            int elapsedTime = 0;
            int lastDeltaTime = targetDeltaTime;
            try
            {
                while (elapsedTime < duration)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    try
                    {
                        Tick(lastDeltaTime);
                    }
                    catch (Exception ex)
                    {
                        // TODO: Logging
                    }

                    stopwatch.Stop();
                    elapsedTime += (int)stopwatch.ElapsedMilliseconds;
                    lastDeltaTime = (int)stopwatch.ElapsedMilliseconds;

                    Task.Delay(Math.Abs(targetDeltaTime - lastDeltaTime)).GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                // TODO: Logging
            }
        }

        protected virtual void Tick(int deltaTime)
        {

        }

        /// <summary>
        /// Put your teardown here.
        /// </summary>
        protected virtual void Teardown()
        {

        }
    }
}
