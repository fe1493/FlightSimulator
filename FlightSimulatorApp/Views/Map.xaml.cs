﻿using System;
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

    public partial class Map : UserControl
    {
        MapViewModel mapVM;
        Location location = new Location() { Latitude = 0, Longitude = 0 };

        public Map()
        {
            InitializeComponent();
        }

        public void Init()
        {
            mapVM = (Application.Current as App).MainViewModel.mapViewModel;
            DataContext = mapVM;
            //this.location = mapVM.VM_Location;
        }
    }
}
