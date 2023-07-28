using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Pump_WPF
{
    public class DisplayModel : ObservableObject
    {
        private string _topString;
        private string _bottomString;
        private string _leftButton1;
        private string _leftButton2;
        private string _leftButton3;
        private string _leftButton4;
        private string _rightButton1;
        private string _rightButton2;
        private string _rightButton3;
        private string _rightButton4;

        public string TopString
        {
            get { return _topString; }
            set { _topString = value; }
        }
        public string BottomString
        {
            get { return _bottomString; }
            set { _bottomString = value; }
        }
        public string LeftButton1
        {
            get { return _leftButton1; }
            set { _leftButton1 = value; }
        }
        public string LeftButton2
        {
            get { return _leftButton2; }
            set { _leftButton2 = value; }
        }
        public string LeftButton3
        {
            get { return _leftButton3; }
            set { _leftButton3 = value; }
        }
        public string LeftButton4
        {
            get { return _leftButton4; }
            set { _leftButton4 = value; }
        }
        public string RightButton1
        {
            get { return _rightButton1; }
            set { _rightButton1 = value; }
        }
        public string RightButton2
        {
            get { return _rightButton2; }
            set { _rightButton2 = value; }
        }
        public string RightButton3
        {
            get { return _rightButton3; }
            set { _rightButton3 = value; }
        }
        public string RightButton4
        {
            get { return _rightButton4; }
            set { _rightButton4 = value; }
        }
    }
}
