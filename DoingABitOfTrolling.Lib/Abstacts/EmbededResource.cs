using DoingABitOfTrolling.Lib.Interfaces;
using System;
using System.Linq;

namespace DoingABitOfTrolling.Lib.Abstacts
{
    public abstract class EmbededResource<T> : IResource<T> where T : class, IDisposable
    {
        protected abstract Lazy<T> resource { get; init; }

        public void Dispose()
        {
            if (resource.IsValueCreated)
                resource.Value.Dispose();
        }

        public T GetValue()
        {
            return resource.Value;
        }
    }
}
