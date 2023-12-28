using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class User
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Level level { get; set; }
        public int password { get; set; }
        public int Points { get; set; }
    }
}
