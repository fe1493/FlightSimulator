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
    public class MapViewModel : INotifyPropertyChanged
    {
        private MySimulatorModel model;
        public MapViewModel(MySimulatorModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            { NotifyPropertyChanged("VM_" + e.PropertyName); };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

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
