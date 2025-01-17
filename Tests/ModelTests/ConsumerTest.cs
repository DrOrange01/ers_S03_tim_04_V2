using Domain.Modeli;
using Domain.Servisi;
using Moq;
using NUnit.Framework;
using Services.DistributionCenterServisi;
using Services.RepozitorijumServisi;
using Services.SolarWindServisi;
using Domain.Repozitorijumi;

namespace Tests.ServicesTests
{
    [TestFixture]
    public class ConsumerTest
    {
        [Test]
        public void Consumer_PrazanKonstruktorTest()
        {
            var consumer = new Consumer();

            Assert.That(consumer.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(consumer.Name, Is.EqualTo(""));
            Assert.That(consumer.uredjaji, Is.Not.Null);
            Assert.That(consumer.uredjaji, Is.Empty);
            Assert.That(consumer.UkupnaPotrosnja, Is.EqualTo(0));
        }

        [Test]
        public void Consumer_KonstruktorSaParametrimaTest()
        {
            var id = Guid.NewGuid();
            var name = "Test Consumer";
            var ukupnaPotrosnja = 123.45;

            var consumer = new Consumer(id, name, ukupnaPotrosnja);

            Assert.That(consumer.Id, Is.EqualTo(id));
            Assert.That(consumer.Name, Is.EqualTo(name));
            Assert.That(consumer.UkupnaPotrosnja, Is.EqualTo(ukupnaPotrosnja));
            Assert.That(consumer.uredjaji, Is.Not.Null);
            Assert.That(consumer.uredjaji, Is.Empty);
        }

        [Test]
        public void Consumer_AddUredjajiTest()
        {
            var consumer = new Consumer();
            var uredjajMock = new Mock<Uredjaji>();
            var uredjaj = uredjajMock.Object;

            consumer.uredjaji.Add(uredjaj);

            Assert.That(consumer.uredjaji, Is.Not.Empty);
            Assert.That(consumer.uredjaji.Count, Is.EqualTo(1));
            Assert.That(consumer.uredjaji[0], Is.EqualTo(uredjaj));
        }
        [Test]
        public void Consumer_UpdateUkupnaPotrosnjaTest()
        {
            var consumer = new Consumer();

            consumer.UkupnaPotrosnja = 150.75;

            Assert.That(consumer.UkupnaPotrosnja, Is.EqualTo(150.75));
        }

        [Test]
        public void Consumer_GenericRepositoryAdd_Test()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Consumer>>();
            var consumer = new Consumer { Name = "Test Consumer" };

            // Act
            mockRepository.Object.Add(consumer);

            // Assert
            mockRepository.Verify(r => r.Add(consumer), Times.Once);
        }

        [Test]
        public void Consumer_GenericRepositoryDelete_Test()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Consumer>>();
            var consumer = new Consumer { Name = "Test Consumer" };

            // Act
            mockRepository.Object.Delete(consumer.Id);

            // Assert
            mockRepository.Verify(r => r.Delete(consumer.Id), Times.Once);
        }
    }
}