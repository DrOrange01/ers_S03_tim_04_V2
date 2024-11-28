using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Modeli;
using Domain.Servisi;

namespace Services.DistributionCenterServisi
{
    public class DistributionCenterServis : IDistributionCenterServis
    {
        public double PosaljiZahtev(double potrosnja, Consumer consumer)
        {
            return potrosnja;
        }
    }
}
