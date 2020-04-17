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
        public MySimulatorModel model;
        public ConnectViewModel connectViewModel;
        public DashboardViewModel dashboardViewModel;
        public JoystickViewModel joystickViewModel;
        public MapViewModel mapViewModel;

        public MainViewModel(MySimulatorModel model)
        {
            this.model = model;
            this.connectViewModel = new ConnectViewModel(this.model);
            this.dashboardViewModel = new DashboardViewModel(this.model);
            this.joystickViewModel = new JoystickViewModel(this.model);
            this.mapViewModel = new MapViewModel(this.model);
        }
    }
}
