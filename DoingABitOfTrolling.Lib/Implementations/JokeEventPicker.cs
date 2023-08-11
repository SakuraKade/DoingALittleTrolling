using DoingABitOfTrolling.Lib.Interfaces;
using System;
using System.Linq;

namespace DoingABitOfTrolling.Lib.Implementations
{
    public class JokeEventPicker : IJokeEventPicker
    {
        bool isDisposed = false;
        List<IJokeEvent> jokeEventList = new List<IJokeEvent>();

        public void Add(IJokeEvent jokeEvent)
        {
            jokeEventList.Add(jokeEvent);
        }

        public void Dispose()
        {
            if (isDisposed) return;

            foreach (IJokeEvent jokeEvent in jokeEventList)
            {
                jokeEvent.Dispose();
            }
            GC.SuppressFinalize(this);
            isDisposed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="Exception"></exception>
        public IJokeEvent Get()
        {
            if (!isDisposed)
                throw new ObjectDisposedException(GetType().Name);
            if (jokeEventList.Count == 0)
                throw new Exception("No JokeEvents added.");

            Random rnd = new Random();
            return jokeEventList[rnd.Next(0, jokeEventList.Count)];
        }
    }
}
