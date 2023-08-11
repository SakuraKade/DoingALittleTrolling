using System;
using System.Linq;

namespace DoingABitOfTrolling.Lib.Interfaces
{
    public interface IJokeEventPicker : IDisposable
    {
        void Add(IJokeEvent jokeEvent);
        IJokeEvent Get();
    }
}
