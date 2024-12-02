using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface IPowerGeneratorServis
    {
        public bool PostaviProizvodnju(double potraznja);
    }
}
