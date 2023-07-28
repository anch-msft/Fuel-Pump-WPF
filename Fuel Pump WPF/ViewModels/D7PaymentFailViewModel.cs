using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Pump_WPF
{
    class D7PaymentFailViewModel: DisplayViewModel
    {
        public D7PaymentFailViewModel()
            :base()
        {
            this.TopString = "CARD NOT AUTHORIZED.";
        }
    }
}
