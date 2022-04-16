using Auvo.ClimaTempoSimples.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auvo.ClimaTempoSimples
{
    public partial class ClimaTempoContext : DbContext, IClimaTempoCompleto
    {
        public ClimaTempoContext()
            : base("name=ClimaTempoContext")
        {
        }

        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<PrevisaoClima> PrevisaoClima { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cidade>()
                .HasMany(e => e.PrevisaoClima)
                .WithRequired(e => e.Cidade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.UF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Cidade)
                .WithRequired(e => e.Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrevisaoClima>()
                .Property(e => e.Clima)
                .IsUnicode(false);

            modelBuilder.Entity<PrevisaoClima>()
                .Property(e => e.TemperaturaMinima)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PrevisaoClima>()
                .Property(e => e.TemperaturaMaxima)
                .HasPrecision(18, 0);
        }

        void IDependency.OnCreate() { }

        void IClimaTempo.Save() => SaveChanges();
        Task<int> IClimaTempo.SaveAsync() => SaveChangesAsync();
        Task<int> IClimaTempo.SaveAsync(CancellationToken cancellationToken) => SaveChangesAsync(cancellationToken);

        void IClimaTempoComCidades.AddCidade(ICidade cidade) => Cidade.Add((Cidade)cidade);
        void IClimaTempoComCidades.AddCidades(IEnumerable<ICidade> cidades) => Cidade.AddRange(cidades.Cast<Cidade>());
        void IClimaTempoComEstados.AddEstado(IEstado estado) => Estado.Add((Estado)estado);
        void IClimaTempoComEstados.AddEstados(IEnumerable<IEstado> estados) => Estado.AddRange(estados.Cast<Estado>());
        void IClimaTempoComPrevisaoClima.AddPrevisaoClima(IPrevisaoClima previsaoClima) => PrevisaoClima.Add((PrevisaoClima)previsaoClima);
        void IClimaTempoComPrevisaoClima.AddPrevisaoClimas(IEnumerable<IPrevisaoClima> previsaoClimas) => PrevisaoClima.AddRange(previsaoClimas.Cast<PrevisaoClima>());

        IQueryable<ICidade> IClimaTempoComCidades.QueryCidade() => Cidade.AsQueryable();
        IQueryable<IEstado> IClimaTempoComEstados.QueryEstado() => Estado.AsQueryable();
        IQueryable<IPrevisaoClima> IClimaTempoComPrevisaoClima.QueryPrevisaoClima() => PrevisaoClima.AsQueryable();

        void IClimaTempoComCidades.RemoveCidade(ICidade cidade) => Cidade.Remove((Cidade)cidade);
        void IClimaTempoComCidades.RemoveCidades(IEnumerable<ICidade> cidades) => Cidade.RemoveRange(cidades.Cast<Cidade>());
        void IClimaTempoComEstados.RemoveEstado(IEstado estado) => Estado.Remove((Estado)estado);
        void IClimaTempoComEstados.RemoveEstados(IEnumerable<IEstado> estados) => Estado.RemoveRange(estados.Cast<Estado>());
        void IClimaTempoComPrevisaoClima.RemovePrevisaoClima(IPrevisaoClima previsaoClima) => PrevisaoClima.Remove((PrevisaoClima)previsaoClima);
        void IClimaTempoComPrevisaoClima.RemovePrevisaoClimas(IEnumerable<IPrevisaoClima> previsaoClimas) => PrevisaoClima.RemoveRange(previsaoClimas.Cast<PrevisaoClima>());
    }
}
