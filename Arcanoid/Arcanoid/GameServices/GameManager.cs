﻿using Arcanoid.GameObjects;
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
                    Scene.AddObject(new Brick(Scene, Brick.BrickType.Green, 80, j * 80, i * 80));
            }
            var bar = new Bar(Scene, "Bar/Bar.png", 0.5, 725, 680);
            Scene.AddObject(bar);

            var ball = new Ball(Scene, "Ball/Ball.png", speed: 0.5, 910,620, 20);
            Scene.AddObject(ball);
            



        }
    }
}
