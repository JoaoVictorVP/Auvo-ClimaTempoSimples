namespace Auvo.ClimaTempoSimples.Core
{
    public interface ICidade
    {
        int Id { get; set; }
        string Nome { get; set; }

        IEstado Estado { get; set; }
    }
}
