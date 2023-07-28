using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Pump_WPF
{
    class D10FuelingInProgressViewModel : DisplayVideoViewModel
    {
        private string _videoName;
        public D10FuelingInProgressViewModel()
            : base()
        {
            this.Title = "FUELING IN PROGRESS.";
            this.VideoName = "Assets/GoogleChromeCastAds480p.mp4";
        }
    }
}
