using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Pump_WPF
{
    class D4RewardsSuccessViewModel : DisplayViewModel
    {
        public D4RewardsSuccessViewModel()
            :base()
        {
            this.TopString = "WOULD YOU LIKE TO USE YOUR DISCOUNT OF 20 CENTS PER GALLON TODAY?";
            this.RightButton3 = "YES >";
            this.RightButton4 = "NO >";
        }
    }
}
