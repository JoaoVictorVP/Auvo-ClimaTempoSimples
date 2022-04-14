using System.Collections;
using System.Collections.Generic;

namespace Auvo.ClimaTempoSimples
{
    public struct UnboundCollection<T, TFrom> : IUnboundCollection<T> where TFrom : T
    {
        ICollection<TFrom> collection;

        public int Count => collection.Count;

        public bool IsReadOnly => collection.IsReadOnly;

        public void Add(T item) => collection.Add((TFrom)item);
        public void Clear() => collection.Clear();
        public bool Contains(T item) => collection.Contains((TFrom)item);
        public void CopyTo(T[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (var item in collection)
            {
                array[i] = item;
                i++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collection)
                yield return item;
        }
        public bool Remove(T item) => collection.Remove((TFrom)item);
        IEnumerator IEnumerable.GetEnumerator() => collection.GetEnumerator();

        public UnboundCollection(ICollection<TFrom> collection)
        {
            this.collection = collection;
        }
    }
}