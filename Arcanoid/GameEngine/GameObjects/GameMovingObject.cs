using Arcanoid.GameObjects;
using GameEngine.GameServices;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GameEngine.GameObjects
{
    /// <summary>
    /// המחלקה מהווה בסיס לכל עצם נע
    /// </summary>
    public abstract class GameMovingObject : GameObject
    {
        protected double _dX; //מהירות אופקית
        protected double _dY; //מהירות אנכית
        protected double _ddX; //תאוצה אופקית
        protected double _ddY; //תאוצה אנכית
        protected double _toX; //מיקום היעד בציר אופקי
        protected double _toY; //מיקום היעד בציר אנכי
        protected GameMovingObject(Scene scene, string fileName, double placeX, double placeY) :
            base(scene, fileName, placeX, placeY)
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
        /// <summary>
        /// הפעולה מניעה את העצם
        /// </summary>
        /// <param name="toX"> מיקום היעד האופקי </param>
        /// <param name="toY"> מיקום היעד האנכי </param>
        /// <param name="speed"> מהירות התנועה </param>
        /// <param name="acceleration"> תאוצה </param>
        public void MoveTo(double toX, double toY, double speed = 1, double acceleration = 0)
        {
            _toX = toX;
            _toY = toY;

            var len = Math.Sqrt(Math.Pow(_toX - _X, 2) + Math.Pow(_toY - _Y, 2));
            var cos = (_toX - _X) / len;
            var sin = (_toY - _Y) / len;

            speed *= Constans.SpeedUnit;
            _dX = speed * cos;
            _dY = speed * sin;

            _ddX = acceleration * cos;
        }
        public virtual void Stop()
        {
            _dX = _dY = _ddX = _ddY = 0;
        }
    }
}
