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
    /// Interaction logic for Joystick.xaml.
    /// </summary>
    /// 

   // Joystick View.
    public partial class Joystick : UserControl, INotifyPropertyChanged
    {
        private Point firstPoint = new Point();
        public event PropertyChangedEventHandler PropertyChanged;

        // Ctor for Joystick View.
        public Joystick()
        {
            InitializeComponent();
        }
        // Rudder Property.
        public double RudderValue
        {
            get { return (double)GetValue(RudderValueProperty); }
            set
            {
                SetValue(RudderValueProperty, value);
            }
        }
        
        public static readonly DependencyProperty RudderValueProperty = DependencyProperty.Register("RudderValue", typeof(double), typeof(Joystick));

        // Elevator Property.
        public double ElevatorValue
        {
            get { return (double)GetValue(ElevatorValueProperty); }
            set
            {
                SetValue(ElevatorValueProperty, value);
            }
        }

        public static readonly DependencyProperty ElevatorValueProperty = DependencyProperty.Register("ElevatorValue", typeof(double), typeof(Joystick));


        // Notify when the property is changed.
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        // Holds the logic for what to do when the mouse is no longer clicked.
        private void Knob_MouseUp(object sender, MouseEventArgs e)
        {
            Knob.ReleaseMouseCapture();
            // Start the animation and reset the values.
            Storyboard sb = this.Knob.FindResource("CenterKnob") as Storyboard;
            // Start the StoryBoard.
            sb.Begin(this, true);
            // Reset the values.
            knobPosition.X = 0.00;
            knobPosition.Y = 0.00;
            this.RudderValue = 0.00;
            this.ElevatorValue = 0.00;
            // Normalize the values.
            Normalize();
        }

        // Holds the logic for what to do when the mouse is being moved.
        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Knob.CaptureMouse();
                // The postitions of the mouse.
                double newX = e.GetPosition(this).X - firstPoint.X;
                double newY = e.GetPosition(this).Y - firstPoint.Y;
                // Check to make sure that we don't allow the knob to go out of its border.
                if (Math.Sqrt(newX * newX + newY * newY) < (Base.Width / 2 - KnobBase.Width / 2) + 2)
                {
                    knobPosition.X = newX;
                    knobPosition.Y = newY;

                }
                // Normalize the values.
                Normalize();
            }
        }

        // Holds the logic for what to do when the mouse is first pressed.
        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                // Get the first point after the left click button on the mouse is pressed.
                firstPoint = e.GetPosition(this);

            }
        }

        // Holds the logic for the Storyboard animation.
        private void centerKnob_Completed(object sender, EventArgs e) 
        {
            // Start the animation and reset the values
            Storyboard sb = this.Knob.FindResource("CenterKnob") as Storyboard;
            sb.Stop(this);
            knobPosition.X = 0;
            knobPosition.Y = 0;
            this.RudderValue = 0.00;
            this.ElevatorValue = 0.00;
        }

        // Resets the joystick if the mouse leaves the restricted area.
        private void Knob_MouseLeave(object sender, MouseEventArgs e)
        {
            Knob.ReleaseMouseCapture();
            // Start the animation and reset the values.
            Storyboard sb = this.Knob.FindResource("CenterKnob") as Storyboard;
            sb.Begin(this, true);
            knobPosition.X = 0.00;
            knobPosition.Y = 0.00;
            this.RudderValue = 0.00;
            this.ElevatorValue = 0.00;
            // Normalize the values.
            Normalize();

        }

        // Normalize the values to between -1 and 1.
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
