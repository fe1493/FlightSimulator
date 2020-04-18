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
        public MainWindow()
        {
            InitializeComponent();
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
            JoystickController.Init();
        }

        

        private void Connect_Loaded(object sender, RoutedEventArgs e)
        {
            connect.Init(JoystickController);
        }

        private void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            dashboard.Init();
        }

        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            MyMap.Init();
        }

        private void ErrorsMassage_Loaded(object sender, RoutedEventArgs e)
        {
            ErrorsMassage.DataContext = (Application.Current as App).MainViewModel.connectViewModel;
        }
    }
}
