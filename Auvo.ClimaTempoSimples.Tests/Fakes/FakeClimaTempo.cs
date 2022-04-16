using Auvo.ClimaTempoSimples;
using Auvo.ClimaTempoSimples.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class FakeClimaTempo : IClimaTempoCompleto
{
    List<IEstado> estados;
    List<ICidade> cidades;
    List<IPrevisaoClima> previsaoClimas;

    public void AddCidade(ICidade cidade)
    {
        if (cidade == null || cidades.Exists(c => c.Id == cidade.Id))
            return;

        cidades.Add(cidade);

        foreach(var previsaoClima in cidade.PrevisaoClima)
        {
            if (previsaoClima.Cidade != cidade)
                previsaoClima.Cidade = cidade;
            AddPrevisaoClima(previsaoClima);
        }

        AddEstado(cidade.Estado);
    }
    public void AddCidades(IEnumerable<ICidade> cidades)
    {
        if (cidades == null)
            return;

        foreach (var cidade in cidades)
            AddCidade(cidade);
    }

    public void AddEstado(IEstado estado)
    {
        if (estado == null || estados.Exists(e => e.Id == estado.Id))
            return;

        estados.Add(estado);
        foreach (var cidade in estado.Cidades)
        {
            if (cidade.Estado != estado)
                cidade.Estado = estado;
            AddCidade(cidade);
        }
    }
    public void AddEstados(IEnumerable<IEstado> estados)
    {
        if (estados == null)
            return;

        foreach (var estado in estados)
            AddEstado(estado);
    }

    public void AddPrevisaoClima(IPrevisaoClima previsaoClima)
    {
        if (previsaoClima == null || previsaoClimas.Exists(p => p.Id == previsaoClima.Id))
            return;
        previsaoClimas.Add(previsaoClima);
        AddCidade(previsaoClima.Cidade);
    }

    public void AddPrevisaoClimas(IEnumerable<IPrevisaoClima> previsaoClimas)
    {
        if (previsaoClimas == null)
            return;

        foreach (var previsaoClima in previsaoClimas)
            AddPrevisaoClima(previsaoClima);
    }

    public IQueryable<ICidade> QueryCidade() => cidades.AsQueryable();
    public IQueryable<IEstado> QueryEstado() => estados.AsQueryable();
    public IQueryable<IPrevisaoClima> QueryPrevisaoClima() => previsaoClimas.AsQueryable();

    public void RemoveCidade(ICidade cidade) => cidades.Remove(cidade);
    public void RemoveCidades(IEnumerable<ICidade> cidades)
    {
        if (cidades == null)
            return;

        foreach (var cidade in cidades)
            this.cidades.Remove(cidade);
    }

    public void RemoveEstado(IEstado estado) => estados.Remove(estado);
    public void RemoveEstados(IEnumerable<IEstado> estados)
    {
        if (estados == null)
            return;

        foreach (var estado in estados)
            this.estados.Remove(estado);
    }

    public void RemovePrevisaoClima(IPrevisaoClima previsaoClima) => previsaoClimas.Remove(previsaoClima);
    public void RemovePrevisaoClimas(IEnumerable<IPrevisaoClima> previsaoClimas)
    {
        if (previsaoClimas == null)
            return;

        foreach (var previsaoClima in previsaoClimas)
            this.previsaoClimas.Remove(previsaoClima);
    }

    void ArrangeRelations()
    {
        foreach (var estado in estados)
            AddEstado(estado);

        foreach (var cidade in cidades)
            AddCidade(cidade);

        foreach (var previsaoClima in previsaoClimas)
            AddPrevisaoClima(previsaoClima);
    }

    public void Save() => ArrangeRelations();
    public Task<int> SaveAsync()
    {
        ArrangeRelations();
        return Task.FromResult(0);
    }

    public Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        ArrangeRelations();
        return Task.FromResult(0);
    }

    void IDisposable.Dispose() { }
    void IDependency.OnCreate()
    {
        estados = new List<IEstado>(32);
        cidades = new List<ICidade>(32);
        previsaoClimas = new List<IPrevisaoClima>(32);
    }
}