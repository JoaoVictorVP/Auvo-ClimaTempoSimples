using Auvo.ClimaTempoSimples;
using Auvo.ClimaTempoSimples.Core;
using System.Collections.Generic;

public class FakeEstado : IEstado
{
    int id;
    string nome, uf;
    List<ICidade> cidades;

    public int Id { get => id; set => id = value; }
    public string Nome { get => nome; set => nome = value; }
    public string UF { get => uf; set => uf = value; }

    public List<ICidade> Cidades => cidades;

    IUnboundCollection<ICidade> IEstado.Cidades => new UnboundCollection<ICidade, ICidade>(cidades);

    public FakeEstado(int id, string nome, string uf, List<ICidade> cidades)
    {
        this.Id = id;
        this.Nome = nome;
        this.UF = uf;
        this.cidades = cidades;
    }

    public FakeEstado()
    {
    }

    void IDependency.OnCreate()
    {
        cidades = new List<ICidade>(32);
    }
}
