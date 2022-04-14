using System.Collections.Generic;

namespace Auvo.ClimaTempoSimples.Core
{
    public interface IEstado
    {
        int Id { get; set; }
        string Nome { get; set; }
        string UF { get; set; }

        IUnboundCollection<ICidade> Cidades { get; }
    }
}
