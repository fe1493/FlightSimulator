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
    /// Interaction logic for JoystickController.xaml
    /// </summary>
    public partial class JoystickController : UserControl
    {
        //JoystickViewModel joystickVM;
        public JoystickController()
        {
            InitializeComponent();
            //joystickVM = new JoystickViewModel(new MySimulatorModel());
            DataContext = this.joystick;
        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {


        }



        private void Throttle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Rudder_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void AileronCoordinates_TextChanged(object sender, TextChangedEventArgs e)
        {



        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

