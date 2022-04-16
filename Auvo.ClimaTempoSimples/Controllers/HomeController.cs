using Auvo.ClimaTempoSimples.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Auvo.ClimaTempoSimples.Controllers
{
    public class HomeController : Controller
    {
        readonly IClimaTempoCompleto db = Service<IClimaTempoCompleto>.Create();

        public ActionResult Index()
        {
            return View(db);
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult ListForecastForCity(int id)
        {
            var city = db.QueryCidade().Where(c => c.Id == id).First();
            return View("ListForecastForCity", city);
        }
    }
}