namespace Auvo.ClimaTempoSimples
{
    using Auvo.ClimaTempoSimples.Core;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using EClima = ClimaTempoSimples.Core.Clima;

    [Table("PrevisaoClima")]
    public partial class PrevisaoClima : IPrevisaoClima
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Clima { get; set; }

        public decimal TemperaturaMinima { get; set; }

        public decimal TemperaturaMaxima { get; set; }

        public DateTime DataPrevisao { get; set; }

        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }

        EClima IPrevisaoClima.Clima { 
            get
            {
                switch(Clima)
                {
                    case nameof(EClima.Ensolarado):
                        return EClima.Ensolarado;

                    case nameof(EClima.Nublado):
                        return EClima.Nublado;

                    case nameof(EClima.Tempestuoso):
                        return EClima.Tempestuoso;

                    default:
                        return EClima.Undefined;
                }
            }
            set
            {
                switch (value)
                {
                    case EClima.Ensolarado:
                        Clima = nameof(EClima.Ensolarado);
                        break;

                    case EClima.Nublado:
                        Clima = nameof(EClima.Nublado);
                        break;

                    case EClima.Tempestuoso:
                        Clima = nameof(EClima.Tempestuoso);
                        break;

                    default:
                        Clima = nameof(EClima.Undefined);
                        break;
                }
            }
        }
        ICidade IPrevisaoClima.Cidade { get => Cidade; set => Cidade = (Cidade)value; }

        void IDependency.OnCreate() { }
    }
}
