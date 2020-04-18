using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Model
{
    /// <summary>
    /// Model Interface
    /// </summary>
    public interface ISimulatorModel : INotifyPropertyChanged
    {
        // Telnet Clinet methods.
        void Connect(string ip, int port);
        void Disconnect();
        void Start();

        // Properties
        string Indicated_heading_deg { set; get; }
        string Gps_indicated_vertical_speed { set; get; }
        string Gps_indicated_ground_speed_kt { set; get; }
        string Airspeed_indicator_indicated_speed_kt { set; get; }
        string Gps_indicated_altitude_ft { set; get; }
        string Attitude_indicator_internal_roll_deg { set; get; }
        string Attitude_indicator_internal_pitch_deg { set; get; }
        string Altimeter_indicated_altitude_ft { set; get; }
        string Error { set; get; }
        void SetAileron(string s);
        void SetElevator(string s);
        void SetRudder(string s);
        void SetThrottle(string s);
        string Location { set; get; }
        string Longitude_deg { set; get; }
        string Latitude_deg { set; get; }
    }
}
