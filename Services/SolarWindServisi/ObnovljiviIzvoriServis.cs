using Domain.Modeli;
using Domain.Servisi;
using Services.LoggerServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SolarWindServisi
{
    public class ObnovljiviIzvoriServis : ISnagaServis
    {
        private readonly Random _random = new Random();
        ILogServis _logger = new FileLoggerServis("Baza.json");
        public void PromeniSnagu(SolarPanelsAndWindGenerators generator)
        {
            if (generator == null)
                throw new ArgumentNullException(nameof(generator), "Generator ne sme biti null.");

            generator.snaga = _random.NextDouble();

            generator.trenutnaProizvodnja = generator.snaga * 5;
            PorukaUDatoteci poruka = new SnagaPoruka(DateTime.Now, generator.snaga, generator.tipGeneratora);
            _logger.Loguj(poruka.ToString() ?? "");
        }
    }
}
