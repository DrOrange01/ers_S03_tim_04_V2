using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Uredjaji
    {
        public int Id { get; set; }
        public string Naziv { get; private set; } = string.Empty;
        public int Potrosnja { get; private set; }
        public bool Ukljucen { get; set; }
        public Uredjaji(int id, string naziv, int potrosnjaPoSatu)
        {
            Id = id;
            Naziv = naziv;
            Potrosnja = potrosnjaPoSatu;
            Ukljucen = false;
        }
    }
}
