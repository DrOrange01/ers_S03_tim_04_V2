using Domain.Modeli;
using Domain.Repozitorijumi;
using Services.RepozitorijumServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Izbor
{
    public class IzborKorisnika
    {
        public List<Consumer> _consumers;
        IRepository<Consumer> userRepository;

        public IzborKorisnika(IRepository<Consumer> _userRepository)
        {
            userRepository = _userRepository;
            _consumers = new List<Consumer>
            {
                new Consumer(Guid.NewGuid(), "Nikola", 0),
                new Consumer(Guid.NewGuid(), "Luka", 0)
            };
            userRepository.Add(_consumers[0]);
            userRepository.Add(_consumers[1]);
            _consumers[0].uredjaji = new List<Uredjaji>
            {
                new Uredjaji(Guid.NewGuid(), "Klima", 4),
                new Uredjaji(Guid.NewGuid(), "Bojler", 5),
                new Uredjaji(Guid.NewGuid(), "Sporet", 6)
            };

            _consumers[1].uredjaji = new List<Uredjaji>
            {
                new Uredjaji(Guid.NewGuid(), "Laptop", 3),
                new Uredjaji(Guid.NewGuid(), "Projektor", 2),
                new Uredjaji(Guid.NewGuid(), "Tv", 4)
            };
        }

        public int ProveriKorisnika(string ime)
        {
            int i = 0;
            foreach (Consumer consumer in _consumers)
            {
                if(consumer.Name.Equals(ime))
                    return i;
                i++;
            }
            return -1;
        }
    }
}
