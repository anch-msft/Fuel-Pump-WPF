using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Pump_WPF
{
    public class MainWindowModel : ObservableObject
    {
        private string _phoneNumber;
        private double _regularPrice;
        private double _plusPrice;
        private double _premiumPrice;
        private double _dieselPrice;
        private double _salePrice;
        private double _gallonsPumped;

        public string PhoneNumber
        {
            get { return _phoneNumber;  }
            set 
            { 
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public double RegularPrice
        {
            get { return _regularPrice; }
            set
            {
                _regularPrice = value;
                OnPropertyChanged("RegularPrice");
            }
        }

        public double PlusPrice
        {
            get { return _plusPrice; }
            set
            {
                _plusPrice = value;
                OnPropertyChanged("PlusPrice");
            }
        }

        public double PremiumPrice
        {
            get { return _premiumPrice; }
            set
            {
                _premiumPrice = value;
                OnPropertyChanged("PremiumPrice");
            }
        }

        public double DieselPrice
        {
            get { return _dieselPrice; }
            set
            {
                _dieselPrice = value;
                OnPropertyChanged("DieselPrice");
            }
        }

        public double SalePrice
        {
            get { return _salePrice; }
            set
            {
                _salePrice = value;
                OnPropertyChanged("SalePrice");
            }
        }


        public double GallonsPumped
        {
            get { return _gallonsPumped; }
            set
            {
                _gallonsPumped = value;
                OnPropertyChanged("GallonsPumped");
            }
        }

    }
}
