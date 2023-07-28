using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Pump_WPF
{
    public class DisplayViewModel : ObservableObject
    {
        private DisplayModel _displayModel;
        public DisplayViewModel()
        {
            _displayModel = new DisplayModel();
            _displayModel.TopString = "INITIALIZATION";
            _displayModel.BottomString = "";
            _displayModel.LeftButton1 = "";
            _displayModel.LeftButton2 = "";
            _displayModel.LeftButton3 = "";
            _displayModel.LeftButton4 = "";
            _displayModel.RightButton1 = "";
            _displayModel.RightButton2 = "";
            _displayModel.RightButton3 = "";
            _displayModel.RightButton4 = "";
        }

        public string TopString
        {
            get { return _displayModel.TopString; }
            set 
            { 
                _displayModel.TopString = value;
                OnPropertyChanged("TopString");
            }
        }

        public string BottomString
        {
            get { return _displayModel.BottomString; }
            set 
            { 
                _displayModel.BottomString = value;
                OnPropertyChanged("BottomString");
            }
        }

        public string LeftButton1
        {
            get { return _displayModel.LeftButton1; }
            set 
            { 
                _displayModel.LeftButton1 = value;
                OnPropertyChanged("LeftButton1");
            }

        }

        public string LeftButton2
        {
            get { return _displayModel.LeftButton2; }
            set 
            { 
                _displayModel.LeftButton2 = value;
                OnPropertyChanged("LeftButton2");
            }
        }

        public string LeftButton3
        {
            get { return _displayModel.LeftButton3; }
            set 
            { 
                _displayModel.LeftButton3 = value;
                OnPropertyChanged("LeftButton3");
            }

        }

        public string LeftButton4
        {
            get { return _displayModel.LeftButton4; }
            set 
            { 
                _displayModel.LeftButton4 = value;
                OnPropertyChanged("LeftButton4");
            }
        }
        public string RightButton1
        {
            get { return _displayModel.RightButton1; }
            set 
            { 
                _displayModel.RightButton1 = value;
                OnPropertyChanged("RightButton1");
            }

        }
        public string RightButton2
        {
            get { return _displayModel.RightButton2; }
            set 
            { 
                _displayModel.RightButton2 = value;
                OnPropertyChanged("RightButton2");
            }
        }
        public string RightButton3
        {
            get { return _displayModel.RightButton3; }
            set 
            { 
                _displayModel.RightButton3 = value;
                OnPropertyChanged("RightButton3");
            }

        }
        public string RightButton4
        {
            get { return _displayModel.RightButton4; }
            set 
            { 
                _displayModel.RightButton4 = value;
                OnPropertyChanged("RightButton4");
            }
        }
    }
}
