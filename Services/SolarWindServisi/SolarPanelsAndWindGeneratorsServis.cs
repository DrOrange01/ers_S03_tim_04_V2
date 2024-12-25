using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Servisi;
using Domain.Modeli;
using Domain.Enumeracije;

namespace Services.SolarWindServisi
{
    public class SolarPanelsAndWindGeneratorsServis : IPowerGeneratorServis
    {
        private readonly SolarPanelsAndWindGenerators _generator;
        private readonly ISnagaServis _snagaServis;
        
        public SolarPanelsAndWindGeneratorsServis(TipGeneratora tip, ObnovljiviIzvoriServis snagaServis)
        {
            _snagaServis = snagaServis ?? throw new ArgumentNullException(nameof(snagaServis));
            _generator = new SolarPanelsAndWindGenerators(tip, 0, 0);
            
            _snagaServis.PromeniSnagu(_generator);
        }

        public double GetProizvodnja() => _generator.trenutnaProizvodnja;

        public void AzurirajProizvodnju()
        {
            _snagaServis.PromeniSnagu(_generator);
        }
    }
}
