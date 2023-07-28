using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Pump_WPF
{
    class DisplayVideoViewModel : DisplayViewModel
    {
        private string _title;
        private string _videoName;

        public DisplayVideoViewModel()
        {
            _title = "";
            _videoName = "";
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string VideoName
        {
            get { return _videoName; }
            set
            {
                _videoName = value;
                OnPropertyChanged("VideoName");
            }
        }
    }
}
