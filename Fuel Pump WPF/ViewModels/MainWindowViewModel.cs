using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Fuel_Pump_WPF
{
    public class MainWindowViewModel : ObservableObject
    {
        private MainWindowModel _currentMainWindow;
        private DisplayViewModel _displayViewModel;
        private string _appState;
        private ICommand _pressedEnter;
        private ICommand _addCharacterToPhoneNumber;
        private ICommand _clearPhoneNumber;
        private ICommand _displayButtonPress;
        private ICommand _reInitializeCommand;
        private ICommand _paymentCommand;
        private ICommand _fuelSelectorCommand;
        private ICommand _beginFuelingCommand;
        private DispatcherTimer _dispatcherTimer;
        private double _discountAmount;
        private Random _rand;
        private double _selectedFuelPrice;
        private double _fuelTankCapacity;

        public MainWindowViewModel()
        {
            _currentMainWindow = new MainWindowModel();
            this.PhoneNumberString = "";
            this.RegularPrice = 4.79;
            this.PlusPrice = 4.89;
            this.PremiumPrice = 4.99;
            this.DieselPrice = 4.89;
            this.SalePrice = 0;
            this.GallonsPumped = 0;

            _displayViewModel = new D1WelcomeViewModel();
            this.CurrentDisplayViewModel = _displayViewModel;

            _dispatcherTimer = new DispatcherTimer();
            _rand = new Random();

            _discountAmount = 0;
            _selectedFuelPrice = 0;
            _fuelTankCapacity = 13 + _rand.NextDouble() * 2;

            _appState = "Welcome";
        }

        private void ReInitialize()
        {
            _dispatcherTimer.Stop();

            this.PhoneNumberString = "";
            this.RegularPrice = 4.79;
            this.PlusPrice = 4.89;
            this.PremiumPrice = 4.99;
            this.DieselPrice = 4.89;
            this.SalePrice = 0;
            this.GallonsPumped = 0;

            this.CurrentDisplayViewModel = new D1WelcomeViewModel();

            _discountAmount = 0;
            _selectedFuelPrice = 0;
            _fuelTankCapacity = 13 + _rand.NextDouble() * 2;

            _appState = "Welcome";
        }

        public double RegularPrice
        {
            get { return _currentMainWindow.RegularPrice; }
            set
            {
                _currentMainWindow.RegularPrice = value;
                OnPropertyChanged("RegularPrice");
            }
        }
        public double PlusPrice
        {
            get { return _currentMainWindow.PlusPrice; }
            set
            {
                _currentMainWindow.PlusPrice = value;
                OnPropertyChanged("PlusPrice");
            }
        }
        public double PremiumPrice
        {
            get { return _currentMainWindow.PremiumPrice; }
            set
            {
                _currentMainWindow.PremiumPrice = value;
                OnPropertyChanged("PremiumPrice");
            }
        }
        public double DieselPrice
        {
            get { return _currentMainWindow.DieselPrice; }
            set
            {
                _currentMainWindow.DieselPrice = value;
                OnPropertyChanged("DieselPrice");
            }
        }
        public double SalePrice
        {
            get { return _currentMainWindow.SalePrice; }
            set
            {
                _currentMainWindow.SalePrice = value;
                OnPropertyChanged("SalePrice");
            }
        }
        public double GallonsPumped
        {
            get { return _currentMainWindow.GallonsPumped; }
            set
            {
                _currentMainWindow.GallonsPumped = value;
                OnPropertyChanged("GallonsPumped");
            }
        }
        public string PhoneNumberString
        {
            get { return _currentMainWindow.PhoneNumber; }
            set { _currentMainWindow.PhoneNumber = value; }
        }

        public DisplayViewModel CurrentDisplayViewModel
        {
            get { return _displayViewModel; }
            set
            {
                if (_displayViewModel != value)
                {
                    _displayViewModel = value;
                    OnPropertyChanged("CurrentDisplayViewMOdel");
                }
            }
        }
        public ICommand PressedEnter
        {
            get
            {
                if (_pressedEnter == null)
                {
                    _pressedEnter = new RelayCommand(param => EnterNextUC());
                }
                return _pressedEnter;
            }
        }

        public ICommand AddCharacterToPhoneNumber
        {
            get
            {
                if (_addCharacterToPhoneNumber == null)
                {
                    _addCharacterToPhoneNumber = new RelayCommand(param => AppendNumber(param));
                }
                return _addCharacterToPhoneNumber;
            }
        }

        public ICommand ClearPhoneNumber
        {
            get
            {
                if (_clearPhoneNumber == null)
                {
                    _clearPhoneNumber = new RelayCommand(param => ClearPhone());
                }
                return _clearPhoneNumber;
            }
        }

        public ICommand DisplayButtonPress
        {
            get
            {
                if (_displayButtonPress == null)
                {
                    _displayButtonPress = new RelayCommand(param => DisplayButtonHandler(param));
                }
                return _displayButtonPress;
            }
        }

        public ICommand ReInitializeCommand
        {
            get
            {
                if (_reInitializeCommand == null)
                {
                    _reInitializeCommand = new RelayCommand(param => ReInitialize());
                }
                return _reInitializeCommand;
            }
        }

        public ICommand PaymentInsertion
        {
            get
            {
                if (_paymentCommand == null)
                {
                    _paymentCommand = new RelayCommand(param => PaymentButtonHandler());
                }
                return _paymentCommand;
            }
        }
        public ICommand FuelSelectorCommand
        {
            get
            {
                if (_fuelSelectorCommand == null)
                {
                    _fuelSelectorCommand = new RelayCommand(param => FuelSelectorHandler(param));
                }
                return _fuelSelectorCommand;
            }
        }

        public ICommand BeginFuelingCommand
        {
            get
            {
                if (_beginFuelingCommand == null)
                {
                    _beginFuelingCommand = new RelayCommand(param => BeginFueling());
                }
                return _beginFuelingCommand;
            }
        }

        private void PaymentButtonHandler()
        {
            if (_appState == "Payment" || _appState == "Welcome")
            {
                CurrentDisplayViewModel = new D6PaymentValidationViewModel();
                _appState = "PaymentValidation";
                PaymentValidation();
            }
        }

        private void DisplayButtonHandler(object num)
        {
            string strval = num.ToString();

            if (_appState == "RewardsSuccess")
            {
                if (strval == "7")
                {
                    _discountAmount = 0.2;
                    DieselPrice = _currentMainWindow.DieselPrice - _discountAmount;
                    RegularPrice = _currentMainWindow.RegularPrice - _discountAmount;
                    PlusPrice = _currentMainWindow.PlusPrice - _discountAmount;
                    PremiumPrice = _currentMainWindow.PremiumPrice - _discountAmount;
                }
                CurrentDisplayViewModel = new D5PaymentViewModel();
                _appState = "Payment";
            }
        }

        private void EnterNextUC()
        {
            if (_appState == "Welcome")
            {
                CurrentDisplayViewModel = new D2RewardsViewModel();
                _appState = "Rewards";
            }
            else if (_appState == "Rewards")
            {
                CurrentDisplayViewModel = new D3PhoneValidationViewModel();
                _appState = "PhoneValidation";
                PhoneValidation();
            }
        }
        private void ClearPhone()
        {
            if (_appState == "Rewards")
            {
                this.PhoneNumberString = "";
                _displayViewModel.BottomString = "";
            }
        }

        private void AppendNumber(object num)
        {
            if (_appState == "Rewards")
            {
                string strval = num.ToString();
                this.PhoneNumberString += strval;
                _displayViewModel.BottomString += strval;
            }
        }

        private void PhoneValidation()
        {
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(3);
            _dispatcherTimer.Tick += PhoneValidationCallback;
            _dispatcherTimer.Start();
        }

        private void PhoneValidationCallback(object sender, EventArgs e)
        {
            _dispatcherTimer.Tick -= PhoneValidationCallback;
            _dispatcherTimer.Stop();
            if (0 == _rand.Next(0, 2))
            {
                CurrentDisplayViewModel = new D4RewardsFailViewModel();
                _appState = "RewardsFail";
                _dispatcherTimer.Tick += RewardsFailCallback;
                _dispatcherTimer.Start();
            }
            else
            {
                CurrentDisplayViewModel = new D4RewardsSuccessViewModel();
                _appState = "RewardsSuccess";
            }
        }

        private void RewardsFailCallback(object sender, EventArgs e)
        {
            _dispatcherTimer.Tick -= RewardsFailCallback;
            _dispatcherTimer.Stop();
            CurrentDisplayViewModel = new D5PaymentViewModel();
            _appState = "Payment";
        }

        private void PaymentValidation()
        {
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(3);
            _dispatcherTimer.Tick += PaymentValidationCallback;
            _dispatcherTimer.Start();
        }

        private void PaymentValidationCallback (object sender, EventArgs e)
        {
            _dispatcherTimer.Tick -= PaymentValidationCallback;
            _dispatcherTimer.Stop();
            if (0 == _rand.Next(0, 5))
            {
                CurrentDisplayViewModel = new D7PaymentFailViewModel();
                _appState = "PaymentFail";
                _dispatcherTimer.Tick += PaymentFailCallback;
                _dispatcherTimer.Start();
            }
            else
            {
                CurrentDisplayViewModel = new D7PaymentSuccessViewModel();
                _appState = "PaymentSuccess";
                _dispatcherTimer.Tick += PaymentSuccessCallback;
                _dispatcherTimer.Start();
            }
        }

        private void PaymentFailCallback(object sender, EventArgs e)
        {
            _dispatcherTimer.Tick -= PaymentFailCallback;
            _dispatcherTimer.Stop();
            CurrentDisplayViewModel = new D5PaymentViewModel();
            _appState = "Payment";
        }

        private void PaymentSuccessCallback(object sender, EventArgs e)
        {
            _dispatcherTimer.Tick -= PaymentSuccessCallback;
            _dispatcherTimer.Stop();
            CurrentDisplayViewModel = new D8SelectFuelViewModel();
            _appState = "SelectFuel";
        }

        private void FuelSelectorHandler(object val)
        {
            if (_appState == "SelectFuel")
            {
                string strval = val.ToString();
                if (strval == "Diesel")
                {
                    RegularPrice = PlusPrice = PremiumPrice = -1;
                    _selectedFuelPrice = DieselPrice;
                }
                else if (strval == "Regular")
                {
                    DieselPrice = PlusPrice = PremiumPrice = -1;
                    _selectedFuelPrice = RegularPrice;
                }
                else if (strval == "Plus")
                {
                    DieselPrice = RegularPrice = PremiumPrice = -1;
                    _selectedFuelPrice = PlusPrice;
                }
                else if (strval == "Premium")
                {
                    DieselPrice = RegularPrice = PlusPrice = -1;
                    _selectedFuelPrice = PremiumPrice;
                }
                CurrentDisplayViewModel = new D9PumpReadyViewModel();
                _appState = "PumpReady";
            }
        }

        private void BeginFueling()
        {
            if (_appState == "PumpReady")
            {
                CurrentDisplayViewModel = new D10FuelingInProgressViewModel();
                _appState = "Fueling";
                _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(50);
                _dispatcherTimer.Tick += FuelingLoop;
                _dispatcherTimer.Start();
            }
        }
        
        private void FuelingLoop(object sender, EventArgs e)
        {
            // 1 gallon + some small random amount per 5 seconds * 0.05 seconds per tick
            double fuelPerTick = (_rand.NextDouble() * 0.2 + 1) / 5 * 0.05;
            if (GallonsPumped + fuelPerTick < _fuelTankCapacity)
            {
                GallonsPumped += fuelPerTick;
                SalePrice += _selectedFuelPrice * fuelPerTick;
            }
            else
            {
                CurrentDisplayViewModel = new D11ThankYouViewModel();
                _appState = "ThankYou";
            }
        }

        public MainWindowModel CurrentMainWindow
        {
            get { return _currentMainWindow; }
            set
            {
                _currentMainWindow = value;
                OnPropertyChanged("CurrentMainWindow");
            }
        }
    }
}
