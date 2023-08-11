using System;
using System.Linq;

namespace DoingABitOfTrolling.Lib.Interfaces
{
    public interface IResource<T> : IDisposable where T : class, IDisposable
    {
        T GetValue();
    }
}
