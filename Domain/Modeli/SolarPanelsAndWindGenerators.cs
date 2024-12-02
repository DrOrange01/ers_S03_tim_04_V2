using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Servisi;
using Domain.Enumeracije;

namespace Services.SolarWindServisi
{
    public class SolarPanelsAndWindGenerators
    {
        public TipGeneratora tipGeneratora { get; set; }
        public double snaga {  get; set; }
        public double trenutnaProizvodnja { get; set; } = 0;

        public SolarPanelsAndWindGenerators()
        {
        }

        public SolarPanelsAndWindGenerators(TipGeneratora tip, double _snaga, double trenutnaPr)
        {
            tipGeneratora = tip;
            snaga = _snaga;
            trenutnaProizvodnja = trenutnaPr;
        }
    }
}
