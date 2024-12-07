using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class UredjajPoruka : PorukaUDatoteci
    {
        public string Naziv { get; set; } = "";
        public string Korisnik { get; set; } = "";
        public bool Ukljucio {  get; set; }
        public UredjajPoruka(DateTime postavljeno, string naziv, string korisnik, bool ukljucio) : base(postavljeno)
        {
            Naziv = naziv;
            Korisnik = korisnik;
            Ukljucio = ukljucio;
        }

        public override string? ToString()
        {
            if (Ukljucio)
            {
                return $"Korisnik {Korisnik} je ukljucio uredjaj {Naziv}\n" + base.ToString();
            }
            return $"Korisnik {Korisnik} je iskljucio uredjaj {Naziv}\n" + base.ToString();
        }
    }
}
