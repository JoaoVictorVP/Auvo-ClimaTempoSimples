using Auvo.ClimaTempoSimples;
using Auvo.ClimaTempoSimples.Core;
using System;

public class FakePrevisaoClima : IPrevisaoClima
{
    int id;
    Clima clima;
    decimal temperaturaMinima, temperaturaMaxima;
    DateTime dataPrevisao;
    ICidade cidade;

    public int Id { get => id; set => id = value; }
    public Clima Clima { get => clima; set => clima = value; }
    public decimal TemperaturaMinima { get => temperaturaMinima; set => temperaturaMinima = value; }
    public decimal TemperaturaMaxima { get => temperaturaMaxima; set => temperaturaMaxima = value; }
    public DateTime DataPrevisao { get => dataPrevisao; set => dataPrevisao = value; }
    public ICidade Cidade { get => cidade; set
        {
            if(cidade != null && cidade.Id != value.Id)
                cidade.PrevisaoClima.Remove(this);
            cidade = value;
            if (cidade != null && cidade.Id != value.Id)
                cidade.PrevisaoClima.Add(this);
        }
    }

    public FakePrevisaoClima(int id, Clima clima, decimal temperaturaMinima, decimal temperaturaMaxima, DateTime dataPrevisao, ICidade cidade)
    {
        this.Id = id;
        this.Clima = clima;
        this.TemperaturaMinima = temperaturaMinima;
        this.TemperaturaMaxima = temperaturaMaxima;
        this.DataPrevisao = dataPrevisao;
        this.Cidade = cidade;
    }

    public FakePrevisaoClima()
    {
    }

    void IDependency.OnCreate() { }
}
