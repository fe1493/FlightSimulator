using FlightSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.ViewModel
{
    public class ConnectViewModel : INotifyPropertyChanged
    {
        private MySimulatorModel model;
        public ConnectViewModel(MySimulatorModel model)
        {
            this.model = model;
            // every time the model notify about change, the vm also notify about change
            model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public void Connect(string ip, int port)
        {
            model.Connect(ip, port);
        }
        public void Disconnect()
        {
            model.Disconnect();
        }
    }
}

