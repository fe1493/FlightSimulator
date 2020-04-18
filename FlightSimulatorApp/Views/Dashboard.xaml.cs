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

    // The Dashboard View.
    public partial class Dashboard : UserControl
    {

        DashboardViewModel DashboardVM;

        // Ctor for the Dashboard View.
        public Dashboard()
        {
            InitializeComponent();
        }

        // Intialize the different local components.
        public void Init()
        {

            DashboardVM = (Application.Current as App).MainViewModel.dashboardViewModel;
            // Make the DataContext the Dashboard VM.
            DataContext = DashboardVM;
        }


    }
}
