using Domain.Modeli;
using Domain.Servisi;
using Moq;
using NUnit.Framework;
using Services.DistributionCenterServisi;
using Services.RepozitorijumServisi;
using Services.SolarWindServisi;
using Domain.Repozitorijumi;
using Services.HydroGeneratorServisi;

namespace Tests.ModelTests
{
    [TestFixture]
    public class HydroelectricPowerPlantTest
    {
        [Test]
        public void Hydro_KonstruktorBezParametara_Test()
        {
            var powerPlant = new HydroelectricPowerPlant();

            Assert.That(powerPlant.trenutnaProizvodnja, Is.EqualTo(0));
        }

        [Test]
        public void Hydro_KonstruktorSaParametrima_Test()
        {
            double expectedProizvodnja = 150.5;

            var powerPlant = new HydroelectricPowerPlant(expectedProizvodnja);

            Assert.That(powerPlant.trenutnaProizvodnja, Is.EqualTo(expectedProizvodnja));
        }

        [Test]
        public void Hydro_TrenutnaProizvodnja_Test()
        {
            var property = typeof(HydroelectricPowerPlant).GetProperty("trenutnaProizvodnja");

            Assert.That(property.SetMethod.IsPrivate, Is.True);
            Assert.That(property.CanWrite, Is.True);
        }
    }
}
