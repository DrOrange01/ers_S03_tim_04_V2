using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Servisi;

namespace Services.HydroGeneratorServisi
{
    public class HydroelectricPowerPlantServis : IPowerGeneratorServis
    {
        private HydroelectricPowerPlant hydro;

        public HydroelectricPowerPlantServis(double potraznja)
        {
            if (potraznja > 0)
            {
                hydro = new HydroelectricPowerPlant(0);
                hydro.trenutnaProizvodnja = potraznja;
            }
        }

        public double GetProizvodnja() => hydro.trenutnaProizvodnja;
    }
}
