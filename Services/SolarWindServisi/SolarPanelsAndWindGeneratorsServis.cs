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
            generator = new SolarPanelsAndWindGenerators(tip, snaga, snaga * 5);
        }

        public double GetProizvodnja() => generator.trenutnaProizvodnja;
    }
}
