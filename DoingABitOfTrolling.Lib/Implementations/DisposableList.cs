using DoingABitOfTrolling.Lib.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingABitOfTrolling.Lib.Implementations
{
    public class DisposableList<T> : IDisposableList<T> where T : IDisposable
    {
        List<T> list;

        public DisposableList()
        {
            list = new List<T>();
        }

        public T this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => list.Count;

        public bool IsReadOnly => false;

        public void Add(T item) => list.Add(item);

        public void Clear() => list.Clear();

        public bool Contains(T item) => list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

        public void Dispose()
        {
            foreach (T item in list)
                item.Dispose();
        }

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        public int IndexOf(T item) => list.IndexOf(item);

        public void Insert(int index, T item) => list.Insert(index, item);

        public bool Remove(T item) => list.Remove(item);

        public void RemoveAt(int index) => list.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
    }
}
