using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auvo.ClimaTempoSimples
{
    public class Service<TInterface> : IService where TInterface : IDependency
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

        object IService.CreateInstance() => Create();

        object IService.GetSingleton() => Singleton;

        void IService.SetResolver(Type type) => resolver = type;

        void IService.SetSingleton(object singleton)
        {
            if (!(singleton is TInterface))
                throw new Exception($"Need a compatible object singleton with <{typeof(TInterface).Name}>");
            Singleton = (TInterface)singleton;
        }
    }
    public static class Service
    {
        static Dictionary<Type, Type> cached = new Dictionary<Type, Type>(32);

        public static IService For(Type forInterface)
        {
            if (cached.TryGetValue(forInterface, out Type serviceType) is false)
                cached[forInterface] = serviceType = typeof(Service<>).MakeGenericType(forInterface);

            return (IService)Activator.CreateInstance(serviceType);
        }
    }
}