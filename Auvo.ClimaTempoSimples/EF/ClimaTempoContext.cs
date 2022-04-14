using Auvo.ClimaTempoSimples.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Auvo.ClimaTempoSimples
{
    public partial class ClimaTempoContext : DbContext, IClimaTempo
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
    }
}
