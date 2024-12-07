using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Services.SolarWindServisi
{
    public class TimerServis
    {
        private static System.Timers.Timer? _timer;
        public List<SolarPanelsAndWindGeneratorsServis> _panels;
        public TimerServis(List<SolarPanelsAndWindGeneratorsServis> panels)
        {

            _timer = new System.Timers.Timer(10000); 
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            _panels = panels;
        }

        private void OnTimedEvent(object? source, ElapsedEventArgs e)
        {
            foreach (SolarPanelsAndWindGeneratorsServis panel in _panels)
            {
                panel.AzurirajProizvodnju();
            }
        }

    }
}
