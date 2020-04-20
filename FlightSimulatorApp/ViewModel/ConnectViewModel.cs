using FlightSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.ViewModel
{
    /// <summary>
    /// Connect ViewModel Class.
    /// </summary>
    public class ConnectViewModel : INotifyPropertyChanged
    {
        private ISimulatorModel model;

        public ConnectViewModel(ISimulatorModel model)
        {
            this.model = model;
            // Every time the model notify about change, the vm also notify about change.
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

        // Connect to server.
        public void Connect(string ip, string port)
        {
            model.Connect(ip, port);
        }

        // Disconnet from the server.
        public void Disconnect()
        {
            model.Disconnect();
        }

        // Error message.
        public String VM_Error
        {
            get { return model.Error; }
        }
    }
}

