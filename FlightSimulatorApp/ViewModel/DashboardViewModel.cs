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
    class DashboardViewModel : INotifyPropertyChanged
    {
        private MySimulatorModel model;
        public DashboardViewModel(MySimulatorModel model)
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
        //Properties

        public string VM_Indicated_heading_deg
        {
            get
            { return model.Indicated_heading_deg; }
        }

        public string Gps_indicated_vertical_speed
        {
            get
            { return model.Gps_indicated_vertical_speed; }
        }

        public string Gps_indicated_ground_speed_kt
        {
            get
            { return model.Gps_indicated_ground_speed_kt; }
        }

        public string Airspeed_indicator_indicated_speed_kt
        {
            get
            { return model.Airspeed_indicator_indicated_speed_kt; }
        }

        public string Gps_indicated_altitude_ft
        {
            get
            { return model.Gps_indicated_altitude_ft; }
        }

        public string Attitude_indicator_internal_roll_deg
        {
            get
            { return model.Attitude_indicator_internal_roll_deg; }
        }

        public string Attitude_indicator_internal_pitch_deg
        {
            get
            { return model.Attitude_indicator_internal_pitch_deg; }
        }

        public string Altimeter_indicated_altitude_ft
        {
            get
            { return model.Altimeter_indicated_altitude_ft; }
        }


    }
}