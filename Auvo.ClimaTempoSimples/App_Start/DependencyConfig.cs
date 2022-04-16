using Auvo.ClimaTempoSimples.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auvo.ClimaTempoSimples.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            Service<IClimaTempoCompleto>.UseResolver<ClimaTempoContext>();

            Service<IEstado>.UseResolver<Estado>();
            Service<ICidade>.UseResolver<Cidade>();
            Service<IPrevisaoClima>.UseResolver<PrevisaoClima>();
        }
    }
}