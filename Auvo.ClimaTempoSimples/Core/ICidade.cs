namespace Auvo.ClimaTempoSimples.Core
{
    public interface ICidade : IDependency
    {
        int Id { get; set; }
        string Nome { get; set; }

        IEstado Estado { get; set; }

        IUnboundCollection<IPrevisaoClima> PrevisaoClima { get; }
    }
}
