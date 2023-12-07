using Arcanoid.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GameEngine.GameObjects
{
    public abstract class GameMovingObject:GameObject
    {
        protected double _dX;// מהירות אופקית
        protected double _dY;// מהירות אנכית
        protected double _ddX;// תאוצה אופקית
        protected double _ddY;// תאוצה אופקית
        protected double _toX;// מיקום היעד בציר x
        protected double _toY;// מיקום היעד בציר x

        protected GameMovingObject(double placeX, double placeY, string filename, Scene scene) : base(placeX, placeY, filename, scene)
        {
        }
        public override void Render()
        {
            _dX += _ddX;
            _dY += _ddY;
            _X += _dX;
            _Y += _dY;


            if (Math.Abs(_X - _toX) < 4 && Math.Abs(_Y - _toY) < 4)
            {
                Stop();
                _X = _toX; 
                _Y = _toY;
            }
            base.Render();
        }
        public virtual void Stop()
        {
            _dX = _dY = _ddX = _ddY = 0;
        }
        public void MoveTo(double toX, double toY, double speed = 1, double acceleration = 0)
        {
            _toX = toX;
            _toY = toY;


            var len = Math.Sqrt(Math.Pow(_toX - _X, 2) + Math.Pow(_toY - _Y, 2));
            var cos = (_toX - _X);
            var sin = (_toY - _Y);

            speed *= Constans.SpeedUnit;
            _dX = speed* cos;
            _dY = speed* sin;

            _ddX = acceleration* cos;
        }
    }
}
