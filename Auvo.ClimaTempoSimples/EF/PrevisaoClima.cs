namespace Auvo.ClimaTempoSimples
{
    using Auvo.ClimaTempoSimples.Core;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrevisaoClima")]
    public partial class PrevisaoClima : IPrevisaoClima
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Clima { get; set; }

        public decimal TemperaturaMinima { get; set; }

        public decimal TemperaturaMaxima { get; set; }

        public DateTime DataPrevisao { get; set; }

        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
