using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Consumer
    {
        public double UkupnaPotrosnja { get; set; } = 0;

        public Consumer(double ukupnaPotrosnja)
        {
            UkupnaPotrosnja = ukupnaPotrosnja;
        }
    }
}
