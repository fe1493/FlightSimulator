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
using Microsoft.Maps.MapControl.WPF;


namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    /// 

    // Map View.
    public partial class Map : UserControl
    {
        MapViewModel mapVM;

        //Ctor for the  Map View.
        public Map()
        {
            InitializeComponent();
        }

        // Intialize the different local components.
        public void Init()
        {
            mapVM = (Application.Current as App).MainViewModel.mapViewModel;
            // Make the DataContext the MapVM.
            DataContext = mapVM;
        }
    }
}
