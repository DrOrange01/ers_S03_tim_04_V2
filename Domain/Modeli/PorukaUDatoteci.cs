using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public abstract class PorukaUDatoteci
    {
        public DateTime Vreme { get; set; }

        protected PorukaUDatoteci(DateTime vreme)
        {
            Vreme = vreme;

        }
        public override string? ToString()
        {
            return $"{Vreme.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)}";
        }
    }
}
