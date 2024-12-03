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
        SolarPanelsAndWindGenerators generator;
        public SolarPanelsAndWindGeneratorsServis(TipGeneratora tip)
        {
            Random rnd = new Random();
            double snaga = rnd.NextDouble();
            generator = new SolarPanelsAndWindGenerators(tip, snaga, 0);
        }
        public bool PostaviProizvodnju(double potraznja)
        {
            if(potraznja<0) return false;

            generator.trenutnaProizvodnja = generator.snaga * 5;
            return true;
        }
        public double GetProizvodnja() => generator.trenutnaProizvodnja;
    }
}
