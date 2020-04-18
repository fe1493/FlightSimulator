using FlightSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorApp.ViewModel
{
    // Map ViewModel.
    public class MapViewModel : INotifyPropertyChanged
    {
        private MySimulatorModel model;
        public event PropertyChangedEventHandler PropertyChanged;


        // Ctor for Map ViewModel.
        public MapViewModel(MySimulatorModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            { NotifyPropertyChanged("VM_" + e.PropertyName); };
        }

        // Notify when property is changed.
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        //Properties for the Map ViewModel connected to the Model.

        public string VM_Latitude_deg
        {
            get
            { return this.model.Latitude_deg; }
        }

        public string VM_Longitude_deg
        {
            get
            { return this.model.Longitude_deg; }
        }
        public string VM_Location
        {
            get
            {
                return model.Location;
            }
        }
    }
}
