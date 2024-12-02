using Domain.Repozitorijumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Consumer : IAggregateRoot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public List<Uredjaji> uredjaji {  get; set; } = new List<Uredjaji>();
        public double UkupnaPotrosnja { get; set; } = 0;

        public Consumer()
        {

        }

        public Consumer(Guid id, string name, double ukupnaPotrosnja)
        {
            Id = id;
            Name = name;
            UkupnaPotrosnja = ukupnaPotrosnja;
        }
    }
}
