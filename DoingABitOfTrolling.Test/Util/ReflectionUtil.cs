using System;
using System.Linq;

namespace DoingABitOfTrolling.Test.Util
{
    internal class ReflectionUtil
    {
        public T[]? GetOfType<T>()
        {
            Type type = typeof(T);
            T[]? values = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(p => p.IsAssignableFrom(type)).ToArray() as T[];
            return values;
        }
    }
}
