using Arcanoid.GameObjects;
using DataBase.Models;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.WiFiDirect;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;

namespace Arcanoid.GameServices
{
    public  class GameManager : Manager
    {
        public static User User { get; set; } = new User();
        
        public GameManager(Scene scene) : base(scene)
        {
            User.level = Pages.LevelsPage.level;
            Init();
        }

        private void Init()
        {
            List<int> colors = Enumerable.Range(0, User.level.CountYellowJelly).Select(_ => 2)
           .Concat(Enumerable.Range(0, User.level.CountPinkJelly).Select(_ => 1))
           .Concat(Enumerable.Range(0, User.level.CountGreenJelly).Select(_ => 0))
           .ToList();

            Random rng = new Random();
            colors = colors.OrderBy(x => rng.Next()).ToList();

            for (int i = 0, c = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Scene.AddObject(new Brick(Scene, (Brick.BrickType)colors[c], 120, j * 120, i * 120));
                    c++;
                }
            }



            var bar = new Bar(Scene, "Bar/Bar.png", 1, Scene.ActualWidth / 2 - (User.level.BarWidth / 2), 650, User.level.BarWidth);
            Scene.AddObject(bar);

            var ball = new Ball(Scene, "Ball/Ball.png", speed: User.level.BallSpeed, Scene.ActualWidth / 2 - 13, 620, 20);
            Scene.AddObject(ball);
            



        }
    }
}
