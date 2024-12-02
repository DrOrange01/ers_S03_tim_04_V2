using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Servisi;
using Domain.Modeli;
using Domain.Enumeracije;

namespace Services.SolarWindServisi
{
    public class SolarPanelsAndWindGeneratorsServis : IPowerGeneratorServis
    {
        SolarPanelsAndWindGenerators solar;
        public SolarPanelsAndWindGeneratorsServis(TipGeneratora tip)
        {
            Random rnd = new Random();
            double snaga = rnd.NextDouble();
            solar = new SolarPanelsAndWindGenerators(tip, snaga, snaga*5);
        }
        public bool PostaviProizvodnju(double potraznja)
        {
            return true;
        }
    }
}
