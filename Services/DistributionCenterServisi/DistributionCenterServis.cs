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
using System.Timers;
using Services.LoggerServisi;

namespace Services.DistributionCenterServisi
{
    public class DistributionCenterServis : IDistributionCenterServis
    {
        private HydroelectricPowerPlantServis? hydroServis;
        private readonly List<SolarPanelsAndWindGeneratorsServis> obnovljiviIzvori;
        ObnovljiviIzvoriServis snagaServis = new ObnovljiviIzvoriServis();
        ILogServis _logger = new FileLoggerServis("DistributionCenterLog.txt");
        TimerServis _timerServis;

        public DistributionCenterServis()
        {
            
            obnovljiviIzvori = new List<SolarPanelsAndWindGeneratorsServis>
            {
                new SolarPanelsAndWindGeneratorsServis(TipGeneratora.SolarPanel, snagaServis),
                new SolarPanelsAndWindGeneratorsServis(TipGeneratora.WindGenerator, snagaServis)
            };
            _timerServis = new TimerServis(obnovljiviIzvori);
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
            PorukaUDatoteci poruka = new EnergijaPoruka(DateTime.Now, potrosnja, hydroProizvodnja);
            _logger.Loguj(poruka.ToString());
            return cena;
        }
    }
}
