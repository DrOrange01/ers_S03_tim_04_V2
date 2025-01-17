using Domain.Modeli;
using Domain.Servisi;
using Moq;
using NUnit.Framework;
using Services.HydroGeneratorServisi;

namespace Tests.ServicesTests
{
    [TestFixture]
    public class HydroelectricPowerPlantServisTest
    {
        [Test]
        public void HydroServis_KonstruktorBezParametara_Test()
        {
            var service = new HydroelectricPowerPlantServis();

            Assert.That(service.GetProizvodnja(), Is.EqualTo(0));
        }

        [Test]
        public void HydroServis_KonstruktorSaParametrima_Test()
        {
            double expectedProizvodnja = 100;
            double negativeProizvodnja = -50;

            var service = new HydroelectricPowerPlantServis(expectedProizvodnja);

            Assert.That(service.GetProizvodnja(), Is.EqualTo(expectedProizvodnja));

            service = new HydroelectricPowerPlantServis(negativeProizvodnja);

            Assert.That(service.GetProizvodnja(), Is.EqualTo(0));
        }
    }
}
