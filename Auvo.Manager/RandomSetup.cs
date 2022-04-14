using Auvo.ClimaTempoSimples;
using Auvo.ClimaTempoSimples.Core;
using System;
using System.Collections.Generic;

public class RandomSetup
{
    public int TempMin { get; set; } = 13;
    public int TempMax { get; set; } = 33;

    Random rand;
    DateTime curDay;

    public List<(string nome, string uf)> States = new List<(string, string)> { ("Minas Gerais", "MG"), ("São Paulo", "SP"), ("Rio de Janeiro", "RJ") };
    public IEnumerable<IEstado> RandomStates()
    {
        foreach (var (nome, uf) in States)
        {
            var state = Service<IEstado>.Create();
            state.Nome = nome;
            state.UF = uf;

            int cityCount = rand.Next(3, 10);
            for (int i = 0; i < cityCount; i++)
            {
                var city = RandomCity();
                state.Cidades.Add(city);
            }

            yield return state;
        }
    }

    public ICidade RandomCity()
    {
        var city = Service<ICidade>.Create();
        city.Nome = RandomCityName(rand);

        int forecastCount = rand.Next(10, 30);

        for(int i = 0; i < forecastCount; i++)
        {
            var forecast = RandomForecast();
            city.PrevisaoClima.Add(forecast);
        }

        return city;
    }

    public IPrevisaoClima RandomForecast()
    {
        var frc = Service<IPrevisaoClima>.Create();

        int climaMin = (int)Clima.Ensolarado, 
            climaMax = (int)Clima.Tempestuoso;

        Clima clima = (Clima)rand.Next(climaMin, climaMax + 1);

        frc.DataPrevisao = curDay;
        frc.Clima = clima;
        frc.TemperaturaMinima = rand.Next(TempMin, TempMax);

        curDay.AddDays(1);

        return frc;
    }

    string[] cityNameParts = new string[] { "mau", "lan", "cas", "ter", "ban", "tis", "man", "loc", "for", "bas", "torh", "plan", "nec" };
    public string RandomCityName(Random rand)
    {
        string name = "";
        int parts = rand.Next(2, 5);
        for (int i = 0; i < parts; i++)
            name += cityNameParts[rand.Next(0, cityNameParts.Length)];
        return name;
    }

    public RandomSetup()
    {
        rand = new Random();
        curDay = DateTime.Now;
    }
}