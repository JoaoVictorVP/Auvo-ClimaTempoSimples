using Auvo.ClimaTempoSimples;
using Auvo.ClimaTempoSimples.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
            Setup();
            InitDB();
            InsertRandomData();
        }
        static void Setup()
        {
            Service<IClimaTempoCompleto>.UseResolver(typeof(ClimaTempoContext));

            Service<IEstado>.UseResolver(typeof(Estado));
            Service<ICidade>.UseResolver(typeof(Cidade));
            Service<IPrevisaoClima>.UseResolver(typeof(PrevisaoClima));
        }
        static void InitDB()
        {
            string sql = File.ReadAllText("script.sql");

            using (var conn = new SqlConnection("data source=.;initial catalog=ClimaTempoSimples;integrated security=True"))
            {
                var command = new SqlCommand(sql, conn);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        static void InsertRandomData()
        {
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
