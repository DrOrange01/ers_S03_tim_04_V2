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
    public class SolarPanelsAndWindGeneratorsServisTest
    {
        [Test]
        public void SolarPanelsAndWindGeneratorsServis_Konstruktor_Test()
        {
            // Arrange
            var snagaServisMock = new Mock<ISnagaServis>();
            snagaServisMock.Setup(s => s.PromeniSnagu(It.IsAny<SolarPanelsAndWindGenerators>()))
                .Callback<SolarPanelsAndWindGenerators>(g => g.trenutnaProizvodnja = 100);

            // Act
            var servis = new SolarPanelsAndWindGeneratorsServis(TipGeneratora.WindGenerator, snagaServisMock.Object);

            // Assert
            Assert.That(servis.GetProizvodnja(), Is.EqualTo(100));
        }
    }
}
