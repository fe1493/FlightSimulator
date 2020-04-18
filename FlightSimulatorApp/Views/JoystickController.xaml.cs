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
    /// Interaction logic for JoystickController.xaml.
    /// </summary>
   // The Joystick Controller View.
    public partial class JoystickController : UserControl
    {
        JoystickViewModel joystickVM;

        // Ctor for the Joystick Controller View.
        public JoystickController()
        {
            InitializeComponent();
        }

        // Intialize the different local components.
        public void Init()
        {
            joystickVM = (Application.Current as App).MainViewModel.joystickViewModel;
            // Make the DataContext the JoystickVM.
            DataContext = joystickVM;
        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e){}

        private void Throttle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { }
      
        private void Rudder_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { }
     
        private void AileronCoordinates_TextChanged(object sender, TextChangedEventArgs e) { }
  
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
    }
}

