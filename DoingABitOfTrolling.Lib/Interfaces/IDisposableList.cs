using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingABitOfTrolling.Lib.Interfaces
{
    public interface IDisposableList<T> : IDisposable, IList<T>, IReadOnlyList<T> where T : IDisposable
    {

    }
}
