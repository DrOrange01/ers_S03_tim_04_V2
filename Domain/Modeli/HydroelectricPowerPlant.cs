using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Servisi;

namespace Services.HydroGeneratorServisi
{
    public class HydroelectricPowerPlant
    {
        public double trenutnaProizvodnja { get; private set; } = 0;

        public HydroelectricPowerPlant() { }

        public HydroelectricPowerPlant(double proizvodnja)
        {
            trenutnaProizvodnja = proizvodnja;
        }
    }
}
