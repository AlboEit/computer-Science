using Arcanoid.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
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
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 19; j++)
                    Scene.AddObject(new Brick(Scene, Brick.BrickType.Green, 200, j * 200, i * 200));
            }
            var platfrom = new Bar(Scene, "Bar/Bar.png", 0.5, 725, 700);
            Scene.AddObject(platfrom);


           
        }
    }
}
