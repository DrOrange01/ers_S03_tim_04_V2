using Domain.Repozitorijumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Uredjaji : IAggregateRoot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Naziv { get; private set; } = string.Empty;
        public int Potrosnja { get; private set; }
        public bool Ukljucen { get; set; }

        public Uredjaji() { }
        public Uredjaji(Guid id, string naziv, int potrosnjaPoSatu)
        {
            Id = id;
            Naziv = naziv;
            Potrosnja = potrosnjaPoSatu;
            Ukljucen = false;
        }
    }
}
