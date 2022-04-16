using Auvo.ClimaTempoSimples.Controllers;
using Auvo.ClimaTempoSimples.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace Auvo.ClimaTempoSimples.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestInitialize]
        public void Setup()
        {
            TestCases.SetupFake();
        }

        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            HomeController controller = new HomeController();

            var result = controller.About() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListForecastForCity()
        {
            HomeController controller = new HomeController();

            // Fill with data
            var accessImpl = new HomeControllerImpl(controller);
            var db = accessImpl.DB;
            var estados = TestCases.FakeEstados(true);
            db.AddEstados(estados);
            db.Save();

            var result = controller.ListForecastForCity(0) as ViewResult;

            Assert.IsNotNull(result);

            db.RemoveEstados(estados);
            db.Save();
        }
    }
}
public class HomeControllerImpl
{
    public readonly HomeController Controller;

    public HomeControllerImpl(HomeController controller)
    {
        Controller = controller;
    }

    public IClimaTempoCompleto DB => (IClimaTempoCompleto)typeof(HomeController).GetField("db", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Controller);
}