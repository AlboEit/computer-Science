using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using static TrafficLights.Objects.TrafficL;

namespace TrafficLights.Objects
{
    internal class TrafficL
    {
        public enum TrafficLightState
        {
            Red = 0 , yellow = 1 , green = 2
        }
        private DispatcherTimer _timer;
        private TrafficLightState _state;

        private Ellipse _elpRed;
        private Ellipse _elpGreen;
        private Ellipse _elpYellow;

        private bool _isAuto;
        public bool IsAuto
        {
            get { return _isAuto; }
            set {
                _isAuto = value;
                    if(_isAuto) { _timer.Start(); }
                else
                {
                    _timer.Stop();
                } 
            }

        }


        public TrafficL(Ellipse elpRed, Ellipse elpYellow, Ellipse elpGreen)
        {
            _elpRed = elpRed;
            _elpYellow = elpYellow;
            _elpGreen = elpGreen;
            _isAuto = false;
            _state = TrafficLightState.Red;
            _timer = new DispatcherTimer();                 //כך יוצרים טיימר

            _timer.Interval = TimeSpan.FromMilliseconds(3000);      //כך קובעים תדירות פעולת הטיימר
            _timer.Stop();                                  //כאשר הטיימר יוצר הוא אהיה במצב דומם
            _timer.Tick += _timer_Tick; ;
        }

        private void _timer_Tick(object sender, object e)
        {
            SetState();
        }



        /// <summary>
        /// The function changes the state of the traffic light.
        /// </summary>
        public void SetState()
        {
            Reset();
            switch (_state)
            {
                
                case TrafficLightState.Red:
                    _state = TrafficLightState.yellow;
                    _elpYellow.Fill = new SolidColorBrush(Colors.Yellow);
                    break;
                case TrafficLightState.yellow:
                    _state = TrafficLightState.green;
                    _elpGreen.Fill = new SolidColorBrush(Colors.Green);
                    break;
                case TrafficLightState.green:
                    _state = TrafficLightState.Red;
                    _elpRed.Fill = new SolidColorBrush(Colors.Red);
                    break;
            }
            if(Events.OnChangeState!=null)//if the event is happening 
            {
                Events.OnChangeState(_state);//starting the event
            }
        }
        /// <summary>
        /// The function Reserts the traffic light colors.
        /// </summary>
        private void Reset()
        {
            _elpRed.Fill = new SolidColorBrush(Colors.Gray);
            _elpYellow.Fill = new SolidColorBrush(Colors.Gray);
            _elpGreen.Fill = new SolidColorBrush(Colors.Gray);
        }
    }
}
