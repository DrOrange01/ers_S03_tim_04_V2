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
        private HydroelectricPowerPlantServis? hydroServis;
        private readonly List<SolarPanelsAndWindGeneratorsServis> obnovljiviIzvori;
        ObnovljiviIzvoriServis snagaServis = new ObnovljiviIzvoriServis();

        public DistributionCenterServis()
        {
            
            obnovljiviIzvori = new List<SolarPanelsAndWindGeneratorsServis>
            {
                new SolarPanelsAndWindGeneratorsServis(TipGeneratora.SolarPanel, snagaServis),
                new SolarPanelsAndWindGeneratorsServis(TipGeneratora.WindGenerator, snagaServis)
            };
        }
        public double PosaljiZahtev(double potrosnja, Consumer consumer)
        {
            double obnovljivaProizvodnjaUkupno = 0;
            double hydroProizvodnja = 0;
            double cena = 0;
            foreach (var izvor in obnovljiviIzvori)
            {
                obnovljivaProizvodnjaUkupno += izvor.GetProizvodnja();
            }
            hydroProizvodnja = potrosnja - obnovljivaProizvodnjaUkupno;
            hydroServis = new HydroelectricPowerPlantServis(hydroProizvodnja);
            cena = obnovljivaProizvodnjaUkupno * 5 + hydroProizvodnja * 10;
            return cena;
        }
    }
}
