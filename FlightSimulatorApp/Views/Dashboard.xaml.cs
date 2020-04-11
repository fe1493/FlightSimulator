using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulatorApp.ViewModel;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    // the property implementation
    // all the variables from the plane
    //private string indicated_heading_deg;
    //  private string gps_indicated_vertical_speed;
    // private string gps_indicated_ground_speed_kt;
    // private string airspeed_indicator_indicated_speed_kt;
    //  private string gps_indicated_altitude_ft;
    //  private string attitude_indicator_internal_roll_deg;
    // private string attitude_indicator_internal_pitch_deg;
    // private string altimeter_indicated_altitude_ft;
    public partial class Dashboard : UserControl
    {
        DashboardViewModel DashboardVM;
        public Dashboard()
        {
            InitializeComponent();
            DataContext = DashboardVM;

        }

        public void Init()
        {
            DashboardVM = (Application.Current as App).MainViewModel.dashboardViewModel;


        }


    }
}
