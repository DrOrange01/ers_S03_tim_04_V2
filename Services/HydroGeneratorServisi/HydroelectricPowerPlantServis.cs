using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Domain.Modeli;
using Domain.Servisi;
using Services.LoggerServisi;

namespace Services.HydroGeneratorServisi
{
    public class HydroelectricPowerPlantServis : IPowerGeneratorServis
    {
        private HydroelectricPowerPlant hydro;

        public HydroelectricPowerPlantServis()
        {
            hydro = new HydroelectricPowerPlant();
        }

        public HydroelectricPowerPlantServis(double potraznja)
        {
            if (potraznja > 0)
            {
                hydro = new HydroelectricPowerPlant(potraznja);
            }
            else
                hydro = new HydroelectricPowerPlant(0);
        }

        public double GetProizvodnja() => hydro.trenutnaProizvodnja;
    }
}
