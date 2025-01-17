using Domain.Modeli;
using Domain.Servisi;
using Moq;
using NUnit.Framework;
using Services.DistributionCenterServisi;
using Services.RepozitorijumServisi;
using Services.SolarWindServisi;
using Domain.Repozitorijumi;

namespace Tests.ModelTests
{
    [TestFixture]
    public class UredjajiTest
    {
        [Test]
        public void Uredjaji_PrazanKonstruktor_Test()
        {
            var uredjaj = new Uredjaji();

            Assert.That(uredjaj.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(uredjaj.Naziv, Is.EqualTo(""));
            Assert.That(uredjaj.Potrosnja, Is.EqualTo(0));
            Assert.That(uredjaj.Ukljucen, Is.False);
        }

        [Test]
        public void Uredjaji_KonstruktorSaParametrima_Test()
        {
            var id = Guid.NewGuid();
            var naziv = "Test Uredjaj";
            var potrosnja = 100;

            var uredjaj = new Uredjaji(id, naziv, potrosnja);

            Assert.That(uredjaj.Id, Is.EqualTo(id));
            Assert.That(uredjaj.Naziv, Is.EqualTo(naziv));
            Assert.That(uredjaj.Potrosnja, Is.EqualTo(potrosnja));
            Assert.That(uredjaj.Ukljucen, Is.False);
        }

        [Test]
        public void Uredjaji_UpdateUkljucen_Test()
        {
            var uredjaj = new Uredjaji();

            uredjaj.Ukljucen = true;

            Assert.That(uredjaj.Ukljucen, Is.True);
        }

        [Test]
        public void Uredjaji_GenericRepositoryAdd_Test()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Uredjaji>>();
            var uredjaj = new Uredjaji(Guid.NewGuid(), "Test Uredjaj", 100);

            // Act
            mockRepository.Object.Add(uredjaj);

            // Assert
            mockRepository.Verify(r => r.Add(uredjaj), Times.Once);
        }

        [Test]
        public void Uredjaji_GenericRepositoryDelete_Test()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Uredjaji>>();
            var uredjaj = new Uredjaji(Guid.NewGuid(), "Test Uredjaj", 100);

            // Act
            mockRepository.Object.Delete(uredjaj.Id);

            // Assert
            mockRepository.Verify(r => r.Delete(uredjaj.Id), Times.Once);
        }
    }
}
