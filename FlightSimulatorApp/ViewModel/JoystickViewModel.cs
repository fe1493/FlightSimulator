using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.ViewModel
{
    //The Joystick ViewModel 
    public class JoystickViewModel : INotifyPropertyChanged
    {
        private MySimulatorModel model;
        public JoystickViewModel(MySimulatorModel model)
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


        public string VM_Elevator
        {
            set
            {
                if (Double.Parse(value) <= 1 && Double.Parse(value) >= -1)
                {
                    model.SetElevator(value);
                }
            }
        }

        public string VM_Rudder
        {
            set
            {
                if (Double.Parse(value) <= 1 && Double.Parse(value) >= -1)
                {
                    model.SetRudder(value);
                }
            }
        }

        public string VM_Throttle
        {
            set
            {
                if (Double.Parse(value) <= 1 && Double.Parse(value) >= 0)
                {
                    model.SetThrottle(value);
                }
            }
        }

        public string VM_Aileron
        {
            set
            {
                if (Double.Parse(value) <= 1 && Double.Parse(value) >= -1)
                {
                    model.SetAileron(value);
                }
            }
        }
    }
}