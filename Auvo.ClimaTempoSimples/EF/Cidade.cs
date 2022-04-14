namespace Auvo.ClimaTempoSimples
{
    using Auvo.ClimaTempoSimples.Core;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cidade")]
    public partial class Cidade : ICidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cidade()
        {
            PrevisaoClima = new HashSet<PrevisaoClima>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrevisaoClima> PrevisaoClima { get; set; }

        IEstado ICidade.Estado { get => Estado; set => Estado = (Estado)value; }

        IUnboundCollection<IPrevisaoClima> ICidade.PrevisaoClima => new UnboundCollection<IPrevisaoClima, PrevisaoClima>(PrevisaoClima);

        void IDependency.OnCreate() { }
    }
}
