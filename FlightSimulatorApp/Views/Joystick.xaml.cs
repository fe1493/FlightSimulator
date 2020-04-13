using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Point firstPoint = new Point();
 
        private double rudderValue;
        private double elevatorValue;

        public Joystick()
        {
            InitializeComponent();
            this.rudderValue = 0.00;
            this.elevatorValue = 0.00;
        }

        public double RudderValue
        {
            get { return (double)GetValue(RudderValueProperty); }
            set
            {
                SetValue(RudderValueProperty, value);
            }
        }

        public static readonly DependencyProperty RudderValueProperty = DependencyProperty.Register("RudderValue", typeof(double), typeof(Joystick));


        public double ElevatorValue
        {
            get { return (double)GetValue(ElevatorValueProperty); }
            set
            {
                SetValue(ElevatorValueProperty, value);
            }
        }

        public static readonly DependencyProperty ElevatorValueProperty = DependencyProperty.Register("ElevatorValue", typeof(double), typeof(Joystick));



        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }


        private void Knob_MouseUp(object sender, MouseEventArgs e)
        {
            //return to the middle once we let go of the mouse
            knobPosition.X = 0.00;
            knobPosition.Y = 0.00;
            this.RudderValue = 0.00;
            this.ElevatorValue = 0.00;
            Normalize();
        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X - firstPoint.X;
                double y = e.GetPosition(this).Y - firstPoint.Y;
                if (Math.Sqrt(x * x + y * y) < (Base.Width / 2 - KnobBase.Width / 2)+2)
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
             
                }
                Normalize();

            }
        }

       

        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                firstPoint = e.GetPosition(this);

            }
        }
        private void centerKnob_Completed(object sender, EventArgs e) { }



        private void Knob_MouseLeave(object sender, MouseEventArgs e)
        {

            knobPosition.X = 0.00;
            knobPosition.Y = 0.00;
            this.RudderValue = 0.00;
            this.ElevatorValue = 0.00;
            Normalize();

        }

        public void Normalize()
        {
            double knobRadius = (Base.Width / 2) - (KnobBase.Width / 2);
            double x = knobPosition.X / knobRadius;
            double y = -(knobPosition.Y / knobRadius);
            this.RudderValue = System.Math.Round(x, 2);
            this.ElevatorValue = System.Math.Round(y, 2);

        }
    }



}
