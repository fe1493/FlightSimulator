using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Model
{
    public class MySimulatorModel : ISimulatorModel
    {
        private Mutex mutex;
        public event PropertyChangedEventHandler PropertyChanged;
        MyTelnetClient telnetClient;

        public MySimulatorModel()
        {
            mutex = new Mutex();
            telnetClient = new MyTelnetClient();
            Location = "32.0055,34.8854";
        }
        public void Connect(string ip, int port)
        {
            try
            {
                Reset();
                telnetClient.Connect(ip, port);
                this.Start();
            }
            catch (Exception e)
            {
                Error = e.Message + "\n";
            }
        }
        public void Disconnect()
        {
            try
            {
                telnetClient.Disconnect();
            }
            catch (Exception e)
            {
                Error = e.Message + "\n";
            }
        }

        public void Reset()
        {
            Indicated_heading_deg = "--";
            Gps_indicated_vertical_speed = "--";
            Gps_indicated_ground_speed_kt = "--";
            Airspeed_indicator_indicated_speed_kt = "--";
            Gps_indicated_altitude_ft = "--";
            Attitude_indicator_internal_roll_deg = "--";
            Attitude_indicator_internal_pitch_deg = "--";
            Altimeter_indicated_altitude_ft = "--";
            Location = "32.0055,34.8854";
        }
        public void Start()
        {
            try
            {
                new Thread(delegate ()
                {
                    while (telnetClient.isConnect)
                    {
                        // update dashboard variables
                        try
                        {
                            mutex.WaitOne();
                            telnetClient.Write("get /instrumentation/heading-indicator/indicated-heading-deg\n");
                            Indicated_heading_deg = telnetClient.Read();
                            Console.WriteLine(Indicated_heading_deg);
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }

                        try
                        {
                            mutex.WaitOne();
                            telnetClient.Write("get /instrumentation/gps/indicated-vertical-speed\n");
                            Gps_indicated_vertical_speed = telnetClient.Read();
                            Console.WriteLine(Gps_indicated_vertical_speed);
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }

                        try
                        {
                            mutex.WaitOne();
                            telnetClient.Write("get /instrumentation/gps/indicated-ground-speed-kt\n");
                            Gps_indicated_ground_speed_kt = telnetClient.Read();
                            Console.WriteLine(gps_indicated_ground_speed_kt);
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }

                        try
                        {
                            mutex.WaitOne();
                            telnetClient.Write("get /instrumentation/airspeed-indicator/indicated-speed-kt\n");
                            Airspeed_indicator_indicated_speed_kt = telnetClient.Read();
                            Console.WriteLine(Airspeed_indicator_indicated_speed_kt);
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }
                        try
                        {
                            mutex.WaitOne();
                            telnetClient.Write("get /instrumentation/gps/indicated-altitude-ft\n");
                            Gps_indicated_altitude_ft = telnetClient.Read();
                            Console.WriteLine(Gps_indicated_altitude_ft);
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }
                        try
                        {
                            mutex.WaitOne();
                            telnetClient.Write("get /instrumentation/attitude-indicator/internal-roll-deg\n");
                            Attitude_indicator_internal_roll_deg = telnetClient.Read();
                            Console.WriteLine(Attitude_indicator_internal_roll_deg);
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }
                        try
                        {
                            mutex.WaitOne();
                            telnetClient.Write("get /instrumentation/attitude-indicator/internal-pitch-deg\n");
                            Attitude_indicator_internal_pitch_deg = telnetClient.Read();
                            Console.WriteLine(Attitude_indicator_internal_pitch_deg);
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }
                        try
                        {
                            mutex.WaitOne();
                            telnetClient.Write("get /instrumentation/altimeter/indicated-altitude-ft\n");
                            Altimeter_indicated_altitude_ft = telnetClient.Read();
                            Console.WriteLine(Altimeter_indicated_altitude_ft);
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }
                        try
                        {
                            mutex.WaitOne();
                            telnetClient.Write("get /position/latitude-deg\n");
                            Latitude_deg = telnetClient.Read();
                            Console.WriteLine(Latitude_deg);
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }
                        try
                        {
                            mutex.WaitOne();
                            telnetClient.Write("get /position/longitude-deg\n");
                            Longitude_deg = telnetClient.Read();
                            Console.WriteLine(Longitude_deg);
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }
                        try
                        {
                            mutex.WaitOne();
                            double Latitude = Convert.ToDouble(this.Latitude_deg);
                            double Longitude = Convert.ToDouble(this.Longitude_deg);
                            if (Longitude > 180 || Longitude < -180 || Latitude > 90 || Latitude < -90)
                            {
                                throw new Exception("Invalid coordinate values");
                            }
                            Location = Latitude + "," + Longitude;
                            mutex.ReleaseMutex();
                        }
                        catch (Exception e)
                        {
                            Error = e.Message + "\n";
                        }
                        //read the data in 4HZ
                        Thread.Sleep(250);
                    }
                }).Start();
            }
            catch (Exception e)
            {
                Error = e.Message + "\n";
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        // the property implementation
        // all the variables from the plane
        private string indicated_heading_deg;
        private string gps_indicated_vertical_speed;
        private string gps_indicated_ground_speed_kt;
        private string airspeed_indicator_indicated_speed_kt;
        private string gps_indicated_altitude_ft;
        private string attitude_indicator_internal_roll_deg;
        private string attitude_indicator_internal_pitch_deg;
        private string altimeter_indicated_altitude_ft;
        private string latitude_deg;
        private string longitude_deg;
        private string location;


        public string Indicated_heading_deg
        {
            get { return indicated_heading_deg; }
            set
            {
                if (value != null)
                {
                    indicated_heading_deg = value;
                    NotifyPropertyChanged("Indicated_heading_deg");
                }
            }
        }
        public string Gps_indicated_vertical_speed
        {
            get { return gps_indicated_vertical_speed; }
            set
            {
                if (value != null)
                {
                    gps_indicated_vertical_speed = value;
                    NotifyPropertyChanged("Gps_indicated_vertical_speed");
                }
            }
        }
        public string Gps_indicated_ground_speed_kt
        {
            get { return gps_indicated_ground_speed_kt; }
            set
            {
                if (value != null)
                {
                    gps_indicated_ground_speed_kt = value;
                    NotifyPropertyChanged("Gps_indicated_ground_speed_kt");
                }
            }
        }
        public string Airspeed_indicator_indicated_speed_kt
        {
            get { return airspeed_indicator_indicated_speed_kt; }
            set
            {
                if (value != null)
                {
                    airspeed_indicator_indicated_speed_kt = value;
                    NotifyPropertyChanged("Airspeed_indicator_indicated_speed_kt");
                }
            }
        }
        public string Gps_indicated_altitude_ft
        {
            get { return gps_indicated_altitude_ft; }
            set
            {
                if (value != null)
                {
                    gps_indicated_altitude_ft = value;
                    NotifyPropertyChanged("Gps_indicated_altitude_ft");
                }
            }
        }
        public string Attitude_indicator_internal_roll_deg
        {
            get { return attitude_indicator_internal_roll_deg; }
            set
            {
                if (value != null)
                {
                    attitude_indicator_internal_roll_deg = value;
                    NotifyPropertyChanged("Attitude_indicator_internal_roll_deg");
                }
            }
        }
        public string Attitude_indicator_internal_pitch_deg
        {
            get { return attitude_indicator_internal_pitch_deg; }
            set
            {
                if (value != null)
                {
                    attitude_indicator_internal_pitch_deg = value;
                    NotifyPropertyChanged("Attitude_indicator_internal_pitch_deg");
                }
            }
        }
        public string Altimeter_indicated_altitude_ft
        {
            get { return altimeter_indicated_altitude_ft; }
            set
            {
                if (value != null)
                {
                    altimeter_indicated_altitude_ft = value;
                    NotifyPropertyChanged("Altimeter_indicated_altitude_ft");
                }
            }
        }
        public string Latitude_deg
        {
            get { return latitude_deg; }
            set
            {
                if (value != null)
                {
                    latitude_deg = value;
                    NotifyPropertyChanged("Latitude_deg");
                }
            }
        }
        public string Longitude_deg
        {
            get { return longitude_deg; }
            set
            {
                if (value != null)
                {
                    longitude_deg = value;
                    NotifyPropertyChanged("Longitude_deg");
                }
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (value != null)
                {
                    location = value;
                    NotifyPropertyChanged("Location");
                }

            }
        }

        public void SetThrottle(string s)
        {
            mutex.WaitOne();
            string toSend = "set " + "/controls/engines/current-engine/throttle " + s + "\n";
            telnetClient.Write(toSend);
            telnetClient.Read();
            mutex.ReleaseMutex();
        }

        public void SetRudder(string s)
        {
            mutex.WaitOne();
            string toSend = "set " + "/controls/flight/rudder " + s + "\n";
            telnetClient.Write(toSend);
            telnetClient.Read();
            mutex.ReleaseMutex();
        }

        public void SetElevator(string s)
        {
            mutex.WaitOne();
            string toSend = "set " + "/controls/flight/elevator " + s + "\n";
            telnetClient.Write(toSend);
            telnetClient.Read();
            mutex.ReleaseMutex();
        }

        public void SetAileron(string s)
        {
            mutex.WaitOne();
            string toSend = "set " + "/controls/flight/aileron " + s + "\n";
            telnetClient.Write(toSend);
            telnetClient.Read();
            mutex.ReleaseMutex();
        }

        // Error message property
        private String error = "";
        public String Error
        {
            get { return this.error; }
            set
            {
                this.error += DateTime.Now.ToString("H:mm:ss : ") + value;
                NotifyPropertyChanged("Error");
            }
        }
    }
}
