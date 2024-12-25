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
        private readonly List<IPowerGeneratorServis> obnovljiviIzvori;
        ObnovljiviIzvoriServis snagaServis = new ObnovljiviIzvoriServis();
        ILogServis _logger = new FileLoggerServis("DistributionCenterLog.txt");
        ILogServis _loggerBaza = new FileLoggerServis("Baza.json");
        TimerServis _timerServis;

        public DistributionCenterServis()
        {
            
            obnovljiviIzvori = new List<IPowerGeneratorServis>
            {
                new SolarPanelsAndWindGeneratorsServis(TipGeneratora.SolarPanel, snagaServis),
                new SolarPanelsAndWindGeneratorsServis(TipGeneratora.WindGenerator, snagaServis)
            };
            _timerServis = new TimerServis(obnovljiviIzvori);
        }
        public DistributionCenterServis(List<IPowerGeneratorServis> obnovljiviIzvori)
        {
            this.obnovljiviIzvori = obnovljiviIzvori;
            _timerServis = new TimerServis(obnovljiviIzvori);
        }
        public double PosaljiZahtev(double potrosnja, Consumer consumer)
        {
            if (potrosnja < 0)
                return -1;
            else if (potrosnja == 0)
                return 0;
            else
            {
                double obnovljivaProizvodnjaUkupno = Math.Min(obnovljiviIzvori.Sum(izvor => izvor.GetProizvodnja()),potrosnja);
                
                double hydroProizvodnja = Math.Max(potrosnja - obnovljivaProizvodnjaUkupno, 0);
                double cena = obnovljivaProizvodnjaUkupno * 5 + hydroProizvodnja * 10;

                hydroServis = new HydroelectricPowerPlantServis(hydroProizvodnja);

                PorukaUDatoteci poruka = new EnergijaPoruka(DateTime.Now, potrosnja, hydroProizvodnja);
                _logger.Loguj(poruka.ToString() ?? "");

                double procenat = hydroProizvodnja / potrosnja * 100;
                PorukaUDatoteci porukaSnaga = new SnagaPoruka(DateTime.Now, procenat, TipGeneratora.HydroelectricPowerPlant);
                _loggerBaza.Loguj(porukaSnaga.ToString() ?? "");
                return cena;
            }
        }
    }
}
