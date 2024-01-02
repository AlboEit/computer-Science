﻿using Arcanoid.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public class GameScene : Scene
    {
        public int BrickCount => _gameObjectSnapshot.Count(x => x is Brick);
    }
}
