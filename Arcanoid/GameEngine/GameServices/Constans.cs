using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameServices
{
    public static class Constans
    {
        public const int SpeedUnit = 10;
        public const double RunInterval = 0.1;

        public enum GameState
        {
            Loaded,
            Started,
            Paused,
            GameOver
        }

    }
}
