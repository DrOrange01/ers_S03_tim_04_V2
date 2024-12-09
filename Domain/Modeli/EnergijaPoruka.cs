using Domain.Enumeracije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class EnergijaPoruka : PorukaUDatoteci
    {
        double Potraznja {  get; set; }
        double PotraznjaOdElektrane { get; set; }

        public EnergijaPoruka(DateTime vreme, double potraznja, double potraznjaOdElektrane) : base(vreme)
        {
            Potraznja = potraznja;
            PotraznjaOdElektrane = potraznjaOdElektrane;
        }
        public override string? ToString()
        {
            return $"Korisnik je trazio {Potraznja}kW elektricne energije\nProizvodnja hidroelektrane je postavljena na {PotraznjaOdElektrane}\nVreme dogadjaja: " + base.ToString() +"\n";
        }
    }
}
