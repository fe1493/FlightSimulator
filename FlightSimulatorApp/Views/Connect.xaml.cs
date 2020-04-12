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
    /// Interaction logic for Connect.xaml
    /// </summary>
    public partial class Connect : UserControl
    {
        public ConnectViewModel vm;
        Boolean stop = true;
        public Connect()
        {
            InitializeComponent();
            IP_Textbox.Text = ConfigurationManager.AppSettings.Get("IP");
            PORT_Textbox.Text = ConfigurationManager.AppSettings.Get("PORT");
        }

        public void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (stop)
            {
                stop = false;
                vm.Connect(IP_Textbox.Text, Int32.Parse(PORT_Textbox.Text));
            }
                
        }
        public void Init()
        {
            vm = (Application.Current as App).MainViewModel.connectViewModel;
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (!stop)
            {
                stop = true;
                vm.Disconnect();
            }
        }
    }
}
