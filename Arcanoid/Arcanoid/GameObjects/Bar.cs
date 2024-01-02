using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Background;
using Windows.System;

namespace Arcanoid.GameObjects
{
    public class Bar:GameMovingObject
    {
        public double dX => _dX;
        public double _speed;
        /// <summary>
        /// הפעולה בונה עצם פךטפורמה
        /// </summary>
        /// <param name="scene">במת המשחק</param>
        /// <param name="fileName"> שם הקובץ של הפלטפורמה </param>
        /// <param name="speed"> מהירות אופקית </param>
        /// <param name="placeX"> מיקום היווצרות בציר אופקי </param>
        /// <param name="PlaceY"> מיקום היווצרות בציר אנכי </param>
        public Bar(Scene scene, String fileName, double speed, double placeX, double PlaceY,double Width) :
            base(scene, fileName, placeX, PlaceY)
        {
            Image.Width = Width;
            _speed = speed;

            // כך הפךטפורמה נרשמת לאירועים הקשורים למקלדת
            Manager.GameEvent.OnKeyDown += HandleKeyDown;
            Manager.GameEvent.OnKeyUp += HandleKeyUp;
        }
        public double Get_X()
        {
            return _X;
        }
        public double Get_Y()
        {
            return _Y;
        }
        public double GetWidth()
        {
            return Width;
        }
        private void HandleKeyUp(VirtualKey key)
        {
            switch (key)
            {
                case VirtualKey.Left:
                case VirtualKey.Right:
                    Stop();
                    break;
            }
        }

        private void HandleKeyDown(VirtualKey key)
        {
            switch (key)
            {
                case VirtualKey.Left:
                    MoveTo(int.MinValue, _Y, _speed);
                    break;
                case VirtualKey.Right:
                    MoveTo(int.MaxValue, _Y, _speed);
                    break;
            }
        }

        public override void Render()
        {
            base.Render();
            if (_X <= 0)
            {
                _X = 0;
                Stop();
            }
            else if (_X >= _scene?.ActualWidth - Width)
            {
                _X = _scene.ActualWidth - Width;
                Stop();
            }
        }
    }
}
