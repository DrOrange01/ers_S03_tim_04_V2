using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Consumer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Uredjaji> uredjaji {  get; set; } = new List<Uredjaji>();
        public double UkupnaPotrosnja { get; set; } = 0;

        public Consumer()
        {

        }

        public Consumer(int id, string name, double ukupnaPotrosnja)
        {
            Id = id;
            Name = name;
            UkupnaPotrosnja = ukupnaPotrosnja;
        }
    }
}
