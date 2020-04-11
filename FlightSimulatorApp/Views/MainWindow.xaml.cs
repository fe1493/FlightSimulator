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
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //SimulatorViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            //vm = new SimulatorViewModel(new MySimulatorModel(new MyTelnetClient()));
            //DataContext = vm;

        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Map_Loaded(object sender, RoutedEventArgs e)
        {
            // myMap.Mode = new AerialMode(true);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void JoystickController_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Map_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void Map_Loaded_2(object sender, RoutedEventArgs e)
        {

        }

        private void Connect_Loaded(object sender, RoutedEventArgs e)
        {
            connect.Init();
        }

        private void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            dashboard.Init();
        }
    }
}
