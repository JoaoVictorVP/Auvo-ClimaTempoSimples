using Auvo.ClimaTempoSimples.Tests.Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.ClimaTempoSimples.Tests.Fakes.Tests
{
    [TestClass]
    public class FakeTestClimaTempo : GenericTestClimaTempo
    {
        [TestInitialize]
        public override void Setup() => TestCases.SetupFake();
    }
}
