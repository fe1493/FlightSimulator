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
        //    public string Throttle
        //    {
        //        get { return model.Throttle; }
        //    }

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

        //    public string Aileron
        //    {
        //        get { return model.Aileron; }
        //    }

        //    public string Rudder
        //    {
        //        get { return model.Rudder; }
        //    }

        //}
    }
}