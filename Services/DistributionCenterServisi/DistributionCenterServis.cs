using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enumeracije;
using Domain.Modeli;
using Domain.Servisi;
using Services.HydroGeneratorServisi;
using Services.SolarWindServisi;

namespace Services.DistributionCenterServisi
{
    public class DistributionCenterServis : IDistributionCenterServis
    {
        private readonly HydroelectricPowerPlantServis hydroServis;
        private readonly List<SolarPanelsAndWindGeneratorsServis> obnovljiviIzvori;

        public DistributionCenterServis()
        {
            hydroServis = new HydroelectricPowerPlantServis(1.1);
            obnovljiviIzvori = new List<SolarPanelsAndWindGeneratorsServis>
            {
                new SolarPanelsAndWindGeneratorsServis(TipGeneratora.SolarPanel),
                new SolarPanelsAndWindGeneratorsServis(TipGeneratora.WindGenerator)
            };
        }
        public void AžurirajProizvodnju(double potraznja)
        {
            // Ažuriraj proizvodnju za sve obnovljive izvore
            foreach (var izvor in obnovljiviIzvori)
            {
                //izvor.PostaviProizvodnju(potraznja);
            }
        }
        public double PosaljiZahtev(double potrosnja, Consumer consumer)
        {
            return potrosnja;
        }
    }
}
