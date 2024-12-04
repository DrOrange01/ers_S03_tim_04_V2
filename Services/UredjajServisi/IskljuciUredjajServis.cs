using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UredjajServisi
{
    public class IskljuciUredjajServis
    {
        public bool IskljuciUredjaj(Uredjaji uredjaj)
        {
            if (uredjaj.Ukljucen == true)
            {
                uredjaj.Ukljucen = false;
                Console.WriteLine($"Uredjaj {uredjaj.Naziv} uspesno iskljucen");
                return true;
            }
            return false;
        }
    }
}
