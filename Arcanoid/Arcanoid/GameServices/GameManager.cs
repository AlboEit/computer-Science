using Arcanoid.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Arcanoid.GameServices
{
    public  class GameManager : Manager
    {
        
        public GameManager(Scene scene) : base(scene)
        {
            Init();
        }

        private void Init()
        {
            Scene.RemoveAllObject();
            var brick = new Brick(Brick.BrickType.Green,200,200, Scene,300);
            Scene.AddObject(brick);

            var bar = new Bar(Scene, "Bar/Bar.png", speed: 3, width: 160, Scene.ActualWidth/2 - 80, 100);
            Scene.AddObject(bar);

        }
    }
}
