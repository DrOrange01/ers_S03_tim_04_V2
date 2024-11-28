using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Servisi;
using Domain.Modeli;

namespace Services.SolarWindServisi
{
    public class SolarPanelsAndWindGeneratorsServis : IPowerGeneratorServis
    {
        SolarPanelsAndWindGenerators solar;
        public SolarPanelsAndWindGeneratorsServis()
        {
            solar = new SolarPanelsAndWindGenerators();
        }
        public double VratiPotraznju(double potraznja)
        {
            return solar.trenutnaProizvodnja;
        }
    }
}
