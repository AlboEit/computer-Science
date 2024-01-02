using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Level
    {
        public int Id { get; set; }
        public int LevelNumber { get; set; }
        public double BallSpeed { get; set; }
        public int BarWidth { get; set; }
        public int CountGreenJelly { get; set; }
        public int CountPinkJelly { get; set; }
        public int CountYellowJelly { get; set; }
    }
}
