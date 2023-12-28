using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Level
    {
        public int id { get; set; } 
        public double Ballspeed{ get; set; }
        public int Levelnumber{ get; set; }
        public int BarWidth { get; set; }
        public int CountGreenBrick{ get; set; }
        public int CountYellowBrick { get; set;}
        public int CountPinkBrick { get; set;}
    }
}
