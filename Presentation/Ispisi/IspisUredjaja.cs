using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Ispisi
{
    public class IspisUredjaja
    {
        private readonly Consumer _consumer;

        public IspisUredjaja(Consumer consumer)
        {
            _consumer = consumer;
        }
        public void PrikaziUredjaje()
        {
            foreach (var uredjajj in _consumer.uredjaji)
            {
                Console.WriteLine($" - Device: {uredjajj.Naziv}, In Use: {uredjajj.Ukljucen}");
            }
        }
    }
}
