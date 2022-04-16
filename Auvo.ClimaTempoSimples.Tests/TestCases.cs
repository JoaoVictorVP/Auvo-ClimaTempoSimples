using Auvo.ClimaTempoSimples.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.ClimaTempoSimples.Tests
{
    public static class TestCases
    {
        public static RandomData Random => random;
        static RandomData random = new RandomData();

        public static void SetupFake()
        {
            Service<IClimaTempoCompleto>.UseResolver<FakeClimaTempo>();

            Service<IEstado>.UseResolver<FakeEstado>();
            Service<ICidade>.UseResolver<FakeCidade>();
            Service<IPrevisaoClima>.UseResolver<FakePrevisaoClima>();
        }
        public static void SetupEF()
        {
            Service<IClimaTempoCompleto>.UseResolver<ClimaTempoContext>();

            Service<IEstado>.UseResolver<Estado>();
            Service<ICidade>.UseResolver<Cidade>();
            Service<IPrevisaoClima>.UseResolver<PrevisaoClima>();
        }

        public static ICidade FakeCidade()
        {
            var cidade = random.RandomCity();
            Assert.IsNotNull(cidade);
            cidade.Id = 0;

            return cidade;
        }
        public static IEnumerable<ICidade> FakeCidades()
        {
            var cidades = new List<ICidade>(32);
            for (int i = 0; i < 32; i++)
            {
                var cidade = random.RandomCity();
                cidade.Id = i;
                cidades.Add(cidade);
            }

            return cidades;
        }

        public static IEstado FakeEstado()
        {
            var estado = random.RandomStates().FirstOrDefault();
            Assert.IsNotNull(estado);
            estado.Id = 0;

            return estado;
        }
        public static IEnumerable<IEstado> FakeEstados(bool feedIds = false)
        {
            var genEstados = random.RandomStates();

            var estados = genEstados.ToList();

            if (feedIds)
            {
                for (int i = 0; i < estados.Count; i++)
                {
                    var estado = estados[i];
                    estado.Id = i;
                    for (int j = 0; j < estado.Cidades.Count; j++)
                    {
                        var cidade = estado.Cidades.ElementAt(j);
                        cidade.Id = j;

                        int k = 0;
                        foreach (var previsaoClima in cidade.PrevisaoClima)
                        {
                            previsaoClima.Id = k;
                            k++;
                        }
                    }
                }
            }

            return estados;
        }

        public static IPrevisaoClima FakePrevisaoClima()
        {
            var previsaoClima = random.RandomForecast(DateTime.Now);

            return previsaoClima;
        }
        public static IEnumerable<IPrevisaoClima> FakePrevisaoClimas()
        {
            var previsaoClimas = new List<IPrevisaoClima>(32);

            var date = DateTime.Now;
            for (int i = 0; i < 32; i++)
            {
                var previsaoClima = random.RandomForecast(date);
                previsaoClima.Id = i;
                previsaoClimas.Add(previsaoClima);

                date.AddDays(1);
            }

            return previsaoClimas;
        }
    }
}
