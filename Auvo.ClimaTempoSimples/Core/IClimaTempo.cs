using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Auvo.ClimaTempoSimples.Core
{
    public interface IClimaTempo : IDependency, IDisposable
    {
        void Save();
        Task<int> SaveAsync();
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
    public interface IClimaTempoCompleto : IClimaTempo, IClimaTempoComEstados, IClimaTempoComCidades, IClimaTempoComPrevisaoClima
    { }
    public interface IClimaTempoComCidades : IClimaTempo
    {
        void AddCidade(ICidade cidade);
        void AddCidades(IEnumerable<ICidade> cidades);
        void RemoveCidade(ICidade cidade);
        void RemoveCidades(IEnumerable<ICidade> cidades);
        IQueryable<ICidade> QueryCidade();
    }
    public interface IClimaTempoComEstados : IClimaTempo
    {
        void AddEstado(IEstado estado);
        void AddEstados(IEnumerable<IEstado> estados);
        void RemoveEstado(IEstado estado);
        void RemoveEstados(IEnumerable<IEstado> estados);
        IQueryable<IEstado> QueryEstado();
    }
    public interface IClimaTempoComPrevisaoClima : IClimaTempo
    {
        void AddPrevisaoClima(IPrevisaoClima previsaoClima);
        void AddPrevisaoClimas(IEnumerable<IPrevisaoClima> previsaoClimas);
        void RemovePrevisaoClima(IPrevisaoClima previsaoClima);
        void RemovePrevisaoClimas(IEnumerable<IPrevisaoClima> previsaoClimas);
        IQueryable<IPrevisaoClima> QueryPrevisaoClima();
    }
}
