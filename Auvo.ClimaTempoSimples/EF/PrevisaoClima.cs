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

        [Column(TypeName = "date")]
        public DateTime DataPrevisao { get; set; }

        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }

        EClima IPrevisaoClima.Clima { 
            get
            {
                if (Enum.TryParse(Clima, out EClima clima))
                    return clima;
                return EClima.Undefined;
            }
            set
            {
                Clima = value.ToString();
            }
        }
        ICidade IPrevisaoClima.Cidade { get => Cidade; set => Cidade = (Cidade)value; }

        void IDependency.OnCreate() { }
    }
}
