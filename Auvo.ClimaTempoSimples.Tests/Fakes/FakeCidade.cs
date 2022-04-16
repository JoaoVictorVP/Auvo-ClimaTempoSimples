using Auvo.ClimaTempoSimples;
using Auvo.ClimaTempoSimples.Core;
using System;
using System.Collections.Generic;

public class FakeCidade : ICidade
{
    public int Id { get => id; set => id = value; }
    public string Nome { get => nome; set => nome = value; }
    public IEstado Estado { get => estado; set
        {
            if (estado != null && estado.Id != value.Id)
                estado.Cidades.Remove(this);
            estado = value;
            if (estado != null && estado.Id != value.Id)
                estado.Cidades.Add(this);
        }
    }

    public List<IPrevisaoClima> PrevisaoClima => previsaoClima;

    IUnboundCollection<IPrevisaoClima> ICidade.PrevisaoClima => new UnboundCollection<IPrevisaoClima, IPrevisaoClima>(previsaoClima);

    void IDependency.OnCreate()
    {
        previsaoClima = new List<IPrevisaoClima>(32);
    }

    int id;
    string nome;
    IEstado estado;
    List<IPrevisaoClima> previsaoClima;

    public FakeCidade(int id, string nome, IEstado estado, List<IPrevisaoClima> previsaoClima)
    {
        this.id = id;
        this.nome = nome;
        this.estado = estado;
        this.previsaoClima = previsaoClima;
    }

    public FakeCidade()
    {
    }
}