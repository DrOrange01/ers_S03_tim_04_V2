using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UredjajServisi
{
    public class ObrisiUredjajServis
    {
        public bool ObrisiUredjaj(Consumer consumer, string naziv)
        {
            foreach (Uredjaji uredjaj in consumer.uredjaji)
            {
                if (uredjaj.Naziv.ToLower().Equals(naziv.ToLower()))
                {
                    consumer.uredjaji.Remove(uredjaj);
                    return true;
                }
            }
            return false;
        }
    }
}
