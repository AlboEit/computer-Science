using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace GameEngine.GameServices
{
    public class GameEvent
    {
        public Action OnRun;// זה האירוע שבזכותו כל מי ישרשם ינוע
        public Action OnTClock; //זה האירוע שבזכותו מופעל השעון

        public Action <VirtualKey> OnKeyDown;// האירוע שמי שירשם אליו יוכל להגיב לעזיבת הלחץ
        public Action<VirtualKey> OnKeyUp;// האירוע שמי שירשם אליו יוכל להגיב לליחצת הלחץ    }
    }
}
