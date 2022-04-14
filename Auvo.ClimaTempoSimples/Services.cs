using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auvo.ClimaTempoSimples
{
    public static class Service<TInterface> where TInterface : IDependency
    {
        static Type resolver;
        public static IDependency Singleton { get; private set; }

        public static TInterface Create()
        {
            var dep = (TInterface)Activator.CreateInstance(resolver);
            dep.OnCreate();
            return dep;
        }

        public static void SetSingleton<T>(T singleton) where T : TInterface
        {
            Singleton = singleton;
        }

        public static void UseResolver<T>() where T : TInterface, new()
        {
            resolver = typeof(T);
        }

        public static void UseResolver(Type type)
        {
            if (type.GetInterface(typeof(TInterface).Name) == null)
                throw new NotImplementedException($"Cannot detect any instance of {typeof(TInterface).Name} on this type");

            resolver = type;
        }
    }
    public interface IDependency
    {
        void OnCreate();
    }
    public interface IUnboundCollection<T> : ICollection<T>
    {
    }
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