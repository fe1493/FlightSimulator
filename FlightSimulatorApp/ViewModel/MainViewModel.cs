using FlightSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.ViewModel
{
    /// <summary>
    /// Main ViewModel Class.
    /// </summary>
    public class MainViewModel
    {
        public ISimulatorModel model;
        public ConnectViewModel connectViewModel;
        public DashboardViewModel dashboardViewModel;
        public JoystickViewModel joystickViewModel;
        public MapViewModel mapViewModel;

        public MainViewModel(ISimulatorModel model)
        {
            this.model = model;
            this.connectViewModel = new ConnectViewModel(this.model);
            this.dashboardViewModel = new DashboardViewModel(this.model);
            this.joystickViewModel = new JoystickViewModel(this.model);
            this.mapViewModel = new MapViewModel(this.model);
        }
    }
}
