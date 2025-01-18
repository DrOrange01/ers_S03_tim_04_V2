using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using Domain.Modeli;
using Domain.Repozitorijumi;
using Presentation.Izbor;
using Services.RepozitorijumServisi;

namespace Tests.PresentationTests
{
    [TestFixture]
    public class IzborKorisnikaTest
    {
        private Mock<IRepository<Consumer>> _mockRepo;
        private IzborKorisnika _izborKorisnika;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<IRepository<Consumer>>();

            var consumers = new List<Consumer>
            {
                new Consumer(Guid.NewGuid(), "Nikola", 0),
                new Consumer(Guid.NewGuid(), "Luka", 0)
            };

            _mockRepo.Setup(repo => repo.GetAll()).Returns(consumers);

            _izborKorisnika = new IzborKorisnika(_mockRepo.Object);

        }

        [Test]
        public void IzborKorisnika_KonstruktorConsumer_Test()
        {
            var allConsumers = _izborKorisnika._consumers;
            Assert.That(allConsumers, Has.Count.EqualTo(2));
            Assert.That(allConsumers[0].Name, Is.EqualTo("Nikola"));
            Assert.That(allConsumers[1].Name, Is.EqualTo("Luka"));
        }

        [Test]
        public void IzborKorisnika_KonstruktorUredjaji_Test()
        {
            var nikola = _izborKorisnika._consumers[0];
            var luka = _izborKorisnika._consumers[1];

            Assert.That(nikola.uredjaji, Has.Count.EqualTo(3));
            Assert.That(nikola.uredjaji[0].Naziv, Is.EqualTo("Klima"));
            Assert.That(nikola.uredjaji[1].Naziv, Is.EqualTo("Bojler"));
            Assert.That(nikola.uredjaji[2].Naziv, Is.EqualTo("Sporet"));

            Assert.That(luka.uredjaji, Has.Count.EqualTo(3));
            Assert.That(luka.uredjaji[0].Naziv, Is.EqualTo("Laptop"));
            Assert.That(luka.uredjaji[1].Naziv, Is.EqualTo("Projektor"));
            Assert.That(luka.uredjaji[2].Naziv, Is.EqualTo("Tv"));
        }

        [Test]
        public void IzborKorisnika_ProveriKorisnika_Test()
        {
            int indexNikola = _izborKorisnika.ProveriKorisnika("Nikola");
            int indexLuka = _izborKorisnika.ProveriKorisnika("Luka");
            int index = _izborKorisnika.ProveriKorisnika("Marko");

            Assert.That(indexNikola, Is.EqualTo(0));
            Assert.That(indexLuka, Is.EqualTo(1));
            Assert.That(index, Is.EqualTo(-1));
        }
    }
}
