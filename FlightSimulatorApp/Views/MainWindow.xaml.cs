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
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    
     // MainWindow.
    public partial class MainWindow : Window
    {
        // Ctor for the MainWindow.
        public MainWindow()
        {
            InitializeComponent();
        }

        // Load and and intialize the Joystick Controller.
        private void JoystickController_Loaded(object sender, RoutedEventArgs e)
        {
            JoystickController.Init();
        }


        // Load and and intialize the Connect Mechanism.

        private void Connect_Loaded(object sender, RoutedEventArgs e)
        {
            Connect.Init(JoystickController);
        }

        // Load and and intialize the Dashboard.
        private void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            Dashboard.Init();
        }

        // Load and and intialize the Map.
        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            MyMap.Init();
        }

        // Load and and intialize the Error Message Indicator.
        private void ErrorsMessage_Loaded(object sender, RoutedEventArgs e)
        {
            // Make the DataContext of the Error Message Indicator, the Connect View Model
            ErrorsMessage.DataContext = (Application.Current as App).MainViewModel.connectViewModel;
        }
    }
}
