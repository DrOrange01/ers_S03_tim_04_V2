using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UredjajServisi
{
    public class UkljuciUredjajServis
    {
        public bool UkljuciUredjaj(Uredjaji uredjaj)
        {
            if (uredjaj.Ukljucen == false)
            {
                uredjaj.Ukljucen = true;
                Console.WriteLine($"Uredjaj {uredjaj.Naziv} uspesno ukljucen");
                return true;
            }
            return false;
        }
    }
}
