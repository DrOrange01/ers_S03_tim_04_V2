using NUnit.Framework;
using Moq;
using Domain.Modeli;
using Domain.Servisi;
using Domain.Enumeracije;
using Services.SolarWindServisi;
using System;
using System.Collections.Generic;

namespace Tests.ServicesTests
{
    [TestFixture]
    public class ObnovljiviIzvoriServisTest
    {
        [Test]
        public void PromeniSnagu_Test()
        {
            var generator = new SolarPanelsAndWindGenerators(TipGeneratora.SolarPanel, 0, 0);
            var loggerMock = new Mock<ILogServis>();
            var servis = new ObnovljiviIzvoriServis();

            servis.PromeniSnagu(generator);

            Assert.That(generator.snaga, Is.GreaterThan(0));
            Assert.That(generator.trenutnaProizvodnja, Is.EqualTo(generator.snaga * 5));

            Assert.Throws<ArgumentNullException>(() => servis.PromeniSnagu(null));
        }
    }
}
