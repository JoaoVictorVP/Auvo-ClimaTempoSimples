using System;

namespace Auvo.ClimaTempoSimples
{
    public interface IService
    {
        object GetSingleton();
        void SetSingleton(object singleton);
        object CreateInstance();
        void SetResolver(Type type);
    }
}