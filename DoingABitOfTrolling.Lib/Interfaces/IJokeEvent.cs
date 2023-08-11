using System;
using System.ComponentModel;
using System.Linq;

namespace DoingABitOfTrolling.Lib.Interfaces
{
    public interface IJokeEvent : IDisposable
    {
        string Name { get; }
        string Description { get; }
        float TicksPerSecound { get; }
        float MaxDurationInSecound { get; }
        float MinDurationInSecound { get; }

        Task TickAsync(CancellationToken cancellationToken);
        Task SetupAsync(CancellationToken cancellationToken);
        Task TeardownAsync(CancellationToken cancellationToken);
    }
}
