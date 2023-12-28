﻿using Arcanoid.GameObjects;
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
            Init();
            User.level = Pages.LevelsPage.level;
        }

        private void Init()
        {
            string[] colors = { "Green", "Yellow", "Pink" };
            Scene.RemoveAllObject();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    string randomColor = colors[random.Next(colors.Length)];
                    Brick.BrickType brickType = (Brick.BrickType)Enum.Parse(typeof(Brick.BrickType), randomColor);

                    Scene.AddObject(new Brick(Scene, brickType, 80, j * 80, i * 80));
                }
            }

            var bar = new Bar(Scene, "Bar/Bar.png", 0.5, 725, 650);
            Scene.AddObject(bar);

            var ball = new Ball(Scene, "Ball/Ball.png", speed: 0.5, 910,620, 20);
            Scene.AddObject(ball);
            



        }
    }
}
