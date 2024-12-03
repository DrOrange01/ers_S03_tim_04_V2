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

        public HydroelectricPowerPlantServis()
        {
            hydro = new HydroelectricPowerPlant(0);
        }
        public bool PostaviProizvodnju(double potraznja)
        {
            if (potraznja < 0) return false;

            hydro.trenutnaProizvodnja = potraznja;
            return true;
        }

        public double GetProizvodnja() => hydro.trenutnaProizvodnja;
    }
}
