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
using System.Windows.Media.Animation;


namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Point firstPoint = new Point();
        public Joystick()
        {
            InitializeComponent();
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
            Knob.ReleaseMouseCapture();
            //start the animation and reset the values
            Storyboard sb = this.Knob.FindResource("CenterKnob") as Storyboard;
            sb.Begin(this, true);
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
                Knob.CaptureMouse();
                double newX = e.GetPosition(this).X - firstPoint.X;
                double newY = e.GetPosition(this).Y - firstPoint.Y;
                if (Math.Sqrt(newX * newX + newY * newY) < (Base.Width / 2 - KnobBase.Width / 2) + 2)
                {
                    knobPosition.X = newX;
                    knobPosition.Y = newY;

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

        private void centerKnob_Completed(object sender, EventArgs e) 
        {
            //start the animation and reset the values
            Storyboard sb = this.Knob.FindResource("CenterKnob") as Storyboard;
            sb.Stop(this);
            knobPosition.X = 0;
            knobPosition.Y = 0;
            this.RudderValue = 0.00;
            this.ElevatorValue = 0.00;

        }

        //resets the joystick if the mouse leaves the restricted area
        private void Knob_MouseLeave(object sender, MouseEventArgs e)
        {
            Knob.ReleaseMouseCapture();
            //start the animation and reset the values
            Storyboard sb = this.Knob.FindResource("CenterKnob") as Storyboard;
            sb.Begin(this, true);
            knobPosition.X = 0.00;
            knobPosition.Y = 0.00;
            this.RudderValue = 0.00;
            this.ElevatorValue = 0.00;
            Normalize();

        }

        //Normalize the values to between -1 and 1
        public void Normalize()
        {
            double knobRadius = (Base.Width / 2) - (KnobBase.Width / 2);
            double newX = knobPosition.X / knobRadius;
            double newY = -(knobPosition.Y / knobRadius);
            this.RudderValue = System.Math.Round(newX, 2);
            this.ElevatorValue = System.Math.Round(newY, 2);
            }
        }
}
