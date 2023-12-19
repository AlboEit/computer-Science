using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace Arcanoid.GameObjects
{
    public class Ball : GameMovingObject
    {
        private double _initialSpeed;   // Initial speed of the ball
        private Vector2 _speed;         // Current speed vector of the ball
        public Bar _bar;                 
        public Ball(Scene scene, String fileName, double speed, double PlaceX, double PlaceY, double width) :
            base(scene, fileName, PlaceX, PlaceY)
        {
            _initialSpeed = speed;
            base.Image.Width = width;
            base.Image.Height = width;
            //MoveTo(0, int.MaxValue, _initialSpeed);
            Manager.GameEvent.OnKeyDown += HandleKeyDown;
            Manager.GameEvent.OnKeyUp += HandleKeyUp;
        }
        public  void init()
        {
            MoveTo(0, int.MinValue);

            Manager.GameEvent.OnKeyDown -= HandleKeyDown;
            Manager.GameEvent.OnKeyUp -= HandleKeyUp;
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
                    MoveTo(int.MinValue, _Y, _initialSpeed);
                    break;
                case VirtualKey.Right:
                    MoveTo(int.MaxValue, _Y, _initialSpeed);
                    break;
                case VirtualKey.Up:
                    init();break;
            }
        }




        public override void Render()
        {
            base.Render();  // Render the base object

            // Check if the ball has hit the left or right boundary of the scene
            if (_X >= _scene?.ActualWidth - Width || _X <= 0)
            {
                _dX *= -1;  // Reverse the horizontal speed
               
            }
            // Check if the ball has hit the top or bottom boundary of the scene
            else if (_Y >= _scene?.ActualHeight - Height || _Y <= 0)
            {
                _dY *= -1;  // Reverse the vertical speed
            }
        }
    }
}
