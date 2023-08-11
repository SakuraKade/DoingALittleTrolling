using System;
using System.Linq;

namespace DoingABitOfTrolling.Lib.Interfaces
{
    public interface IJokeEventRunner
    {
        Task RunAsync(IJokeEvent jokeEvent, CancellationToken cancellationToken);
    }
}
