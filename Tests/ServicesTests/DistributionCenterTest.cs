using Domain.Modeli;
using Domain.Servisi;
using Moq;
using NUnit.Framework;
using Services.DistributionCenterServisi;
using Services.SolarWindServisi;

namespace Tests.ServicesTests
{
    [TestFixture]
    public class DistributionCenterTest
    {
        private DistributionCenterServis _distributionCenterServis;
        private Mock<ISnagaServis> _mockSnagaServis;
        private Mock<ILogServis> _mockLogger;
        private Mock<ILogServis> _mockLoggerBaza;

        [SetUp]
        public void SetUp()
        {
            // Mockovi za zavisnosti
            _mockSnagaServis = new Mock<ISnagaServis>();
            _mockLogger = new Mock<ILogServis>();
            _mockLoggerBaza = new Mock<ILogServis>();

            // Kreiranje instance DistributionCenterServis
            _distributionCenterServis = new DistributionCenterServis();
        }

        [Test]
        public void PosaljiZahtevTest()
        {
            double potrosnja = 100;
            var consumer = new Consumer();

            var solarMock = new Mock<IPowerGeneratorServis>();
            var windMock = new Mock<IPowerGeneratorServis>();

            solarMock.Setup(x => x.GetProizvodnja()).Returns(40);
            windMock.Setup(x => x.GetProizvodnja()).Returns(30);

            var obnovljiviIzvoriMock = new List<IPowerGeneratorServis>
            {
                solarMock.Object,
                windMock.Object
            };

            var distributionCenterServis = new DistributionCenterServis(obnovljiviIzvoriMock);

            var result = distributionCenterServis.PosaljiZahtev(potrosnja, consumer);

            Assert.AreEqual(650, result);

            potrosnja = 0;
            result = distributionCenterServis.PosaljiZahtev(potrosnja, consumer);
            Assert.AreEqual(0, result);

            potrosnja = -100;
            result = distributionCenterServis.PosaljiZahtev(potrosnja, consumer);
            Assert.AreEqual(-1, result);
        }
    }
}