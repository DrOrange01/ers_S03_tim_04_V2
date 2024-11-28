using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Servisi;

namespace Services.SolarWindServisi
{
    public class SolarPanelsAndWindGenerators
    {
        public double snagaVetra {  get; set; }
        public double snagaSunca {  get; set; }
        public double trenutnaProizvodnja { get; set; } = 0;

        public SolarPanelsAndWindGenerators()
        {
            Random rndS = new Random();
            Random rndV = new Random();
            snagaSunca = rndS.NextDouble();
            snagaVetra = rndV.NextDouble();
            trenutnaProizvodnja = snagaSunca * 10 + snagaVetra * 10;
        }
    }
}
