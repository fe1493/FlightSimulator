using FlightSimulatorApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Collections.Specialized;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Connect.xaml.
    /// </summary>
    public partial class Connect : UserControl
    {
        public ConnectViewModel vm;
        public JoystickController joystickController;

        public Connect()
        {
            InitializeComponent();
            // Default values of the connection.
            IP_Textbox.Text = ConfigurationManager.AppSettings.Get("IP");
            PORT_Textbox.Text = ConfigurationManager.AppSettings.Get("PORT");
        }

        // Connect to the server and reset all values.
        public void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vm.Connect(IP_Textbox.Text, PORT_Textbox.Text);
            }
            catch (Exception)
            {

            }
            joystickController.Aileron.Value = 0;
            joystickController.Throttle.Value = 0;
        }

        public void Init(JoystickController joystickController)
        {
            vm = (Application.Current as App).MainViewModel.connectViewModel;
            this.joystickController = joystickController;
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            vm.Disconnect();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            vm.Disconnect();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
