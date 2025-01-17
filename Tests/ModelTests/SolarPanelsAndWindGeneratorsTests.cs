using Domain.Enumeracije;
using Domain.Modeli;
using Domain.Servisi;
using Moq;
using NUnit.Framework;
using Services.DistributionCenterServisi;
using Services.RepozitorijumServisi;
using Services.SolarWindServisi;
using Domain;

namespace Tests.ModelTests
{
    [TestFixture]
    public class SolarPanelsAndWindGeneratorsTests
    {
        [Test]
        public void Solar_KonstruktorBezParametara_Test()
        {
            var generator = new SolarPanelsAndWindGenerators();

            Assert.That(generator.tipGeneratora, Is.EqualTo(default(TipGeneratora)));
            Assert.That(generator.snaga, Is.EqualTo(0));
            Assert.That(generator.trenutnaProizvodnja, Is.EqualTo(0));
        }

        [Test]
        public void Solar_KonstruktorSaParametrima_Test()
        {
            var expectedTip = TipGeneratora.SolarPanel;
            var expectedSnaga = 200;
            var expectedTrenutnaProizvodnja = 150;

            var generator = new SolarPanelsAndWindGenerators(expectedTip, expectedSnaga, expectedTrenutnaProizvodnja);

            Assert.That(generator.tipGeneratora, Is.EqualTo(expectedTip));
            Assert.That(generator.snaga, Is.EqualTo(expectedSnaga));
            Assert.That(generator.trenutnaProizvodnja, Is.EqualTo(expectedTrenutnaProizvodnja));
        }

        [Test]
        public void Solar_Propertiji_Test()
        {
            var generator = new SolarPanelsAndWindGenerators();

            generator.tipGeneratora = TipGeneratora.WindGenerator;
            generator.snaga = 300;
            generator.trenutnaProizvodnja = 250;

            Assert.That(generator.tipGeneratora, Is.EqualTo(TipGeneratora.WindGenerator));
            Assert.That(generator.snaga, Is.EqualTo(300));
            Assert.That(generator.trenutnaProizvodnja, Is.EqualTo(250));
        }
    }
}
