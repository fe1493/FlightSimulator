using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Model;
using System.Web;

namespace FlightSimulatorApp.ViewModel
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private MySimulatorModel model;

        public event PropertyChangedEventHandler PropertyChanged;

        // Ctor for the DashboardVM.
        public DashboardViewModel(MySimulatorModel model)
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

        // Properties for the DashboardVM connected to the Model.

        public string VM_Indicated_heading_deg
        {
            get
            { return model.Indicated_heading_deg; }
        }

        public string VM_Gps_indicated_vertical_speed
        {
            get
            { return model.Gps_indicated_vertical_speed; }
        }

        public string VM_Gps_indicated_ground_speed_kt
        {
            get
            { return model.Gps_indicated_ground_speed_kt; }
        }

        public string VM_Airspeed_indicator_indicated_speed_kt
        {
            get
            { return model.Airspeed_indicator_indicated_speed_kt; }
        }

        public string VM_Gps_indicated_altitude_ft
        {
            get
            { return model.Gps_indicated_altitude_ft; }
        }

        public string VM_Attitude_indicator_internal_roll_deg
        {
            get
            { return model.Attitude_indicator_internal_roll_deg; }
        }

        public string VM_Attitude_indicator_internal_pitch_deg
        {
            get
            { return model.Attitude_indicator_internal_pitch_deg; }
        }

        public string VM_Altimeter_indicated_altitude_ft
        {
            get
            { return model.Altimeter_indicated_altitude_ft; }
        }
    }
}