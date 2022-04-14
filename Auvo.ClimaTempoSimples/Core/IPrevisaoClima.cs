using System;

namespace Auvo.ClimaTempoSimples.Core
{
    public interface IPrevisaoClima : IDependency
    {
        int Id { get; set; }
        Clima Clima { get; set; }
        decimal TemperaturaMinima { get; set; }
        decimal TemperaturaMaxima { get; set; }
        DateTime DataPrevisao { get; set; }

        ICidade Cidade { get; set; }
    }
}
