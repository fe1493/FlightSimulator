using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.ViewModel
{
    // The Joystick ViewModel.
    public class JoystickViewModel : INotifyPropertyChanged
    {

        private MySimulatorModel model;
        public event PropertyChangedEventHandler PropertyChanged;

        // Ctor for the Joystick ViewModel. 
        public JoystickViewModel(MySimulatorModel model)
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

        //Properties for the Joystick ViewModel connected to the Model.

        public string VM_Elevator
        {
            set
            {
                // Check if the values are in the correct range.
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
                // Check if the values are in the correct range.
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
                // Check if the values are in the correct range.
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
                // Check if the values are in the correct range.
                if (Double.Parse(value) <= 1 && Double.Parse(value) >= -1)
                {
                    model.SetAileron(value);
                }
            }
        }
    }
}