using Domain.Enumeracije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class SnagaPoruka : PorukaUDatoteci
    {
        public double Snaga {  get; set; }
        public string Vrsta { get; set; }
        public SnagaPoruka(DateTime vreme, double snaga, TipGeneratora vrsta) : base(vreme)
        {
            Snaga = snaga;
            if (vrsta == TipGeneratora.SolarPanel)
            {
                Vrsta = "sunca";
            }
            else if (vrsta == TipGeneratora.WindGenerator)
            {
                Vrsta = "vetra";
            }
            else
                Vrsta = "hidro elektrane";
        }
        public override string? ToString()
        {
            if (!Vrsta.Equals("hidro elektrane"))
            {
                return $"[{base.ToString()}] Snaga {Vrsta} je postavljena na {Snaga}%";
            }
            else
                return $"[{base.ToString()}] Procent ukljucenosti {Vrsta} je {Snaga}%";
        }
    }
}
