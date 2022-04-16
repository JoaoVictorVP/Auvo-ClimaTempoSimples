using Auvo.ClimaTempoSimples.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auvo.ClimaTempoSimples.Tests.Generics
{
    public abstract class GenericTestClimaTempo
    {
        public abstract void Setup();

        [TestMethod]
        public void AddCidade()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var cidade = TestCases.FakeCidade();

            climaTempo.AddCidade(cidade);
            climaTempo.Save();

            Assert.IsNotNull(climaTempo.QueryCidade().Where(city => city.Id == cidade.Id).FirstOrDefault());

            climaTempo.RemoveCidade(cidade);
            climaTempo.Save();
        }
        [TestMethod]
        public void RemoveCidade()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var cidade = TestCases.FakeCidade();

            climaTempo.AddCidade(cidade);
            climaTempo.Save();

            climaTempo.RemoveCidade(cidade);
            climaTempo.Save();

            Assert.IsNull(climaTempo.QueryCidade().Where(city => city.Id == cidade.Id).FirstOrDefault());
        }

        [TestMethod]
        public void QueryCidade()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var cidade = TestCases.FakeCidade();

            climaTempo.AddCidade(cidade);
            climaTempo.Save();

            var queryResult = climaTempo.QueryCidade().Where(city => city.Id == cidade.Id).FirstOrDefault();

            Assert.IsNotNull(queryResult);

            climaTempo.RemoveCidade(cidade);
            climaTempo.Save();
        }

        [TestMethod]
        public void AddCidades()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var cidades = TestCases.FakeCidades();

            climaTempo.AddCidades(cidades);
            climaTempo.Save();

            Assert.IsTrue(climaTempo.QueryCidade().All(c => cidades.Contains(c)));

            climaTempo.RemoveCidades(cidades);
            climaTempo.Save();
        }
        [TestMethod]
        public void RemoveCidades()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var cidades = TestCases.FakeCidades();

            climaTempo.AddCidades(cidades);
            climaTempo.Save();

            climaTempo.RemoveCidades(cidades);
            climaTempo.Save();

            Assert.IsTrue(climaTempo.QueryCidade().All(c => cidades.Contains(c) == false));
        }

        [TestMethod]
        public void AddEstado()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var estado = TestCases.FakeEstado();

            climaTempo.AddEstado(estado);
            climaTempo.Save();

            Assert.IsNotNull(climaTempo.QueryEstado().Where(e => e.Id == estado.Id).FirstOrDefault());

            climaTempo.RemoveEstado(estado);
            climaTempo.Save();
        }
        [TestMethod]
        public void RemoveEstado()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var estado = TestCases.FakeEstado();

            climaTempo.AddEstado(estado);
            climaTempo.Save();

            climaTempo.RemoveEstado(estado);
            climaTempo.Save();

            Assert.IsNull(climaTempo.QueryEstado().Where(e => e.Id == estado.Id).FirstOrDefault());
        }

        [TestMethod]
        public void QueryEstado()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var estado = TestCases.FakeEstado();

            climaTempo.AddEstado(estado);
            climaTempo.Save();

            var queryResult = climaTempo.QueryEstado().Where(e => e.Id == estado.Id).FirstOrDefault();

            Assert.IsNotNull(queryResult);

            climaTempo.RemoveEstado(estado);
            climaTempo.Save();
        }

        [TestMethod]
        public void AddEstados()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var estados = TestCases.FakeEstados();

            climaTempo.AddEstados(estados);
            climaTempo.Save();

            Assert.IsTrue(climaTempo.QueryEstado().All(e => estados.Contains(e)));

            climaTempo.RemoveEstados(estados);
            climaTempo.Save();
        }
        [TestMethod]
        public void RemoveEstados()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var estados = TestCases.FakeEstados();

            climaTempo.AddEstados(estados);
            climaTempo.Save();

            climaTempo.RemoveEstados(estados);
            climaTempo.Save();

            Assert.IsTrue(climaTempo.QueryEstado().All(e => estados.Contains(e) == false));
        }

        [TestMethod]
        public void AddPrevisaoClima()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var previsaoClima = TestCases.FakePrevisaoClima();
            
            climaTempo.AddPrevisaoClima(previsaoClima);
            climaTempo.Save();

            Assert.IsNotNull(climaTempo.QueryPrevisaoClima().Where(p => p.Id == previsaoClima.Id));

            climaTempo.RemovePrevisaoClima(previsaoClima);
            climaTempo.Save();
        }
        [TestMethod]
        public void RemovePrevisaoClima()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var previsaoClima = TestCases.FakePrevisaoClima();

            climaTempo.AddPrevisaoClima(previsaoClima);
            climaTempo.Save();

            climaTempo.RemovePrevisaoClima(previsaoClima);
            climaTempo.Save();

            Assert.IsNull(climaTempo.QueryPrevisaoClima().Where(p => p.Id == previsaoClima.Id).FirstOrDefault());
        }

        [TestMethod]
        public void QueryPrevisaoClima()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var previsaoClima = TestCases.FakePrevisaoClima();

            climaTempo.AddPrevisaoClima(previsaoClima);
            climaTempo.Save();

            var queryResult = climaTempo.QueryPrevisaoClima().Where(p => p.Id == previsaoClima.Id);

            Assert.IsNotNull(queryResult);

            climaTempo.RemovePrevisaoClima(previsaoClima);
            climaTempo.Save();
        }

        [TestMethod]
        public void AddPrevisaoClimas()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var previsaoClimas = TestCases.FakePrevisaoClimas();

            climaTempo.AddPrevisaoClimas(previsaoClimas);
            climaTempo.Save();

            Assert.IsTrue(climaTempo.QueryPrevisaoClima().All(p => previsaoClimas.Contains(p)));

            climaTempo.RemovePrevisaoClimas(previsaoClimas);
            climaTempo.Save();
        }
        [TestMethod]
        public void RemovePrevisaoClimas()
        {
            var climaTempo = Service<IClimaTempoCompleto>.Create();
            Assert.IsNotNull(climaTempo);

            var previsaoClimas = TestCases.FakePrevisaoClimas();

            climaTempo.AddPrevisaoClimas(previsaoClimas);
            climaTempo.Save();

            climaTempo.RemovePrevisaoClimas(previsaoClimas);
            climaTempo.Save();

            Assert.IsTrue(climaTempo.QueryPrevisaoClima().All(p => previsaoClimas.Contains(p) == false));
        }
    }
}
