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
    internal class Bar:GameMovingObject
    {
        public double dX => _X;
        public double _speed;

        public Bar(Scene scene, string fileName , double speed , int width , double placeX , double placeY) : base(placeX, placeY, fileName, scene)
        {
            _speed = speed;
            Image.Height = 25;
            Image.Width = width;
            Image.Stretch = Windows.UI.Xaml.Media.Stretch.Fill;

            Manager.gameEvent.OnKeyDown +=KeyDown ;
            Manager.gameEvent.OnKeyUp+= KeyUp;

        }


        /// <summary>
        /// באמצעות הפעולה הזאת המחבט מגיב לעזיבת המקש
        /// </summary>
        /// <param name="key">המקש שנעזב</param>
        /// <exception cref="NotImplementedException"></exception>
        private void KeyUp(VirtualKey key)
        {
            switch (key)
            {
                case VirtualKey.Left:
                case VirtualKey.Right:
                    Stop() ; break;
            }
        }

        private void KeyDown(VirtualKey key)
        {
            switch (key)
            {
                case VirtualKey.Left:
                    MoveTo(int.MinValue,_Y,_speed,0) ; break;
                case VirtualKey.Right:
                    MoveTo(int.MaxValue, _Y, _speed, 0); break;
            }
        }
        public override void Render()//מתבצעת על הזמן
        {
            base.Render();
            if (_X <+ 0)
            { 
                _X = 0;
                Stop();

            }
            else if (_X>=_scene?.ActualWidth-Width)//כאשר תגע עם הצד הימני שלך בקיר הימני של הזירה 
            {
                _X =_scene.ActualWidth- Width;
                Stop();
            }
        }
    }
}
