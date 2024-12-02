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
        HydroelectricPowerPlant hydro;
        public bool PostaviProizvodnju(double potraznja)
        {
            hydro = new HydroelectricPowerPlant(potraznja);
            return hydro.trenutnaProizvodnja != potraznja;
            
        }
    }
}
