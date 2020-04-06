using FlightSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.ViewModel
{
    public class MainViewModel
    {
        MySimulatorModel model;
        public ConnectViewModel connectViewModel;
        public MainViewModel(MySimulatorModel model)
        {
            this.model = model;
            this.connectViewModel = new ConnectViewModel(this.model);
        }
    }
}
