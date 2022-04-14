using Auvo.ClimaTempoSimples;
using Auvo.ClimaTempoSimples.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Auvo.Manager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("--- Inicializando o banco de dados ---\n");

            Setup();

            bool wasInitialized = InitDB();

            if(wasInitialized)
                InsertRandomData();

            WriteLine("Inicialização Finalizada com Sucesso!!!\n");

            WriteLine("Pressione qualquer tecla para continuar...");

            ReadKey(true);
        }
        static void Setup()
        {
            WriteLine("Injetando dependencias...\n");
            Service<IClimaTempoCompleto>.UseResolver(typeof(ClimaTempoContext));

            Service<IEstado>.UseResolver(typeof(Estado));
            Service<ICidade>.UseResolver(typeof(Cidade));
            Service<IPrevisaoClima>.UseResolver(typeof(PrevisaoClima));
        }
        static bool InitDB()
        {
            WriteLine("Configurando migração do banco de dados...\n");
            try
            {
                var migrationConfig = new DbMigrationsConfiguration<ClimaTempoContext>
                {
                    AutomaticMigrationsEnabled = true,
                    AutomaticMigrationDataLossAllowed = true
                };
                var migrator = new DbMigrator(migrationConfig);
                migrator.Update();

                WriteLine("A migração foi um sucesso!\n");

                return true;
            }
            catch(System.Data.SqlClient.SqlException)
            {
                WriteLine("A migração não foi necessária pois o banco de dados já está configurado!\n");

                return false;
            }
        }
        static void InsertRandomData()
        {
            WriteLine("Inserindo dados aleatórios no banco de dados para consulta...\n");

            var rand = new RandomSetup();

            using (var ctx = Service<IClimaTempoCompleto>.Create())
            {
                var states = rand.RandomStates();

                foreach (var state in states)
                    ctx.AddEstado(state);

                ctx.Save();
            }
        }
    }
}
