using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Uredjaji
    {
        public string Naziv { get; private set; } = string.Empty;
        public int Potrosnja { get; private set; }
        public bool Ukljucen { get; set; }
        public Uredjaji(string naziv, int potrosnjaPoSatu)
        {
            Naziv = naziv;
            Potrosnja = potrosnjaPoSatu;
            Ukljucen = false;
        }
    }
}
