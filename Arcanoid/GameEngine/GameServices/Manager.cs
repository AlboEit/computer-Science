using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameServices
{
    /* המחלקה המופשטת, שדורשת שיהיה לה יורש,היא מחזיקה בבמה, שני טיימרים , חבילת אירועים סטטיסטית ומצב המשחק, המחלקה יוצר שני טיימרים
     * ,
     *  יוצר תחבילת אירועים סטטיתמגילה פעולות התחלת משחק, עצירה, המשך וסיום.
     * 
     * 
     * 
     * 
     * 
     * 
     * 
    */
    public abstract class Manager
    {
        public Scene Scene { get; private set; }

        public Manager(Scene scene) 
        {
            Scene = scene;
        }
    }
}
