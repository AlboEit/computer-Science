using Arcanoid.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }
    }
}
