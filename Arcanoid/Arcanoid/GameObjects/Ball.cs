using Arcanoid.Pages;
using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.Perception.People;
using Windows.System;
using Windows.UI.WebUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.UI;

namespace Arcanoid.GameObjects
{
    public class Ball : GameMovingObject
    {
        private double _initialSpeed;   // Initial speed of the ball
        private double _speed;         // Current speed vector of the ball
        public Bar _bar;
        private int _countLives;
        public int _score;
        // Add these lines to the Ball class
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                // You can add additional logic here if needed
                // For example, updating the score display in the UI
                if (Manager.GameEvent.OnUpdateScore != null)
                {
                    Manager.GameEvent.OnUpdateScore(_score);
                }
            }
        }

        public void AddScore()
        {
            Score += _addedScore;
        }

        private const int _addedScore = 50;
        
        public Ball(Scene scene, String fileName, double speed, double PlaceX, double PlaceY, double width) :
            base(scene, fileName, PlaceX, PlaceY)
        {
            _initialSpeed = 1;
            _speed = speed;
            _countLives = 3;
            _score = 0;

            base.Image.Width = width;
            base.Image.Height = width;
            //MoveTo(0, int.MaxValue, _initialSpeed);
            Manager.GameEvent.OnKeyDown += HandleKeyDown;
            Manager.GameEvent.OnKeyUp += HandleKeyUp;
        }
        public  void init()
        {
            Manager.GameEvent.OnKeyDown += HandleKeyDown;
            Manager.GameEvent.OnKeyUp += HandleKeyUp;
            base.init();
            _scene.init();

            
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
                    
                    Manager.GameEvent.OnKeyDown -= HandleKeyDown;
                    Manager.GameEvent.OnKeyUp -= HandleKeyUp;
                    MoveTo(0, int.MinValue,_speed);
                    break;
            }
        }




        //public override void Render()
        //{
        //    // Render the base object

        //    // Check if the ball has hit the left or right boundary of the scene
        //    if (_X >= _scene?.ActualWidth - Width || _X <= 0)
        //    {
        //        _dX *= -1;  // Reverse the horizontal speed

        //    }
        //    // Check if the ball has hit the top or bottom boundary of the scene
        //    else if (_Y >= _scene?.ActualHeight - Height || _Y <= 0)
        //    {
        //        _dY *= -1;  // Reverse the vertical speed
        //    }
        //    base.Render();
        //}
        public override void Render()
        {
            if (_X >= _scene?.ActualWidth - Width || _X <= 0) {
                _dX *= -1;

            }
            else if (_Y <= 0) {
                _dY *= -1;
            }
            else if(_Y >= _scene?.ActualHeight - Height)
            {
                Stop();
                init();
                if (Manager.GameEvent.OnRemoveHeart != null)
                {
                    Manager.GameEvent.OnRemoveHeart(--_countLives);
                }
            }
            base.Render();
        }

        public override void Collide(GameObject gameObject)
        {
            if (gameObject is Bar platform)
            {
                _dY = -_dY;

                if (Math.Abs(platform.dX) > 0)
                {
                    _dX += platform.dX / 2.6;
                }
                _Y = platform.Rect.Top - Height;
            }
            if (gameObject is Brick brick)
            {
                var intersectRect = RectHelper.Intersect(Rect, brick.Rect);
                if (intersectRect.Height > intersectRect.Width)
                {
                    _X -= _dX;
                    _dX = -_dX;
                }
                else
                {
                    _Y -= _dY;
                    _dY = -_dY;
                }
                brick.ChangeBrick(gameObject);
                AddScore();
            }
        }

    }
}
