using Auvo.ClimaTempoSimples;
using Auvo.ClimaTempoSimples.Controllers;
using Auvo.ClimaTempoSimples.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Auvo.ClimaTempoSimples.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [ClassInitialize]
        public void Setup()
        {
            Service<IClimaTempoCompleto>.UseResolver<ClimaTempoContext>();

            Service<IEstado>.UseResolver<Estado>();
            Service<ICidade>.UseResolver<Cidade>();
            Service<IPrevisaoClima>.UseResolver<PrevisaoClima>();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestClima()
        {

        }
    }
}
