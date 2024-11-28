using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Servisi;

namespace Services.LoggerServisi
{
    //ovde mogu da prosledim putanju u zavisnosti dal mi treba za consumera ili distribution center
    public class FileLoggerServis(string putanja) : ILogServis
    {
        private string _putanja = putanja;

        public void Loguj(string poruka)
        {
            using StreamWriter sw = new(_putanja, append: true);
            sw.Write($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)}]: {poruka}\n");
        }
    }
}
