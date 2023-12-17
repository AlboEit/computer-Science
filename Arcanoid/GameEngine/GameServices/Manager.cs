using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using static GameEngine.GameServices.Constans;

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
        private static DispatcherTimer _runTimer;

        public static GameEvent GameEvent { get; } = new GameEvent();

        public static GameState GameState { get; set; } = GameState.Loaded;
        public Manager(Scene scene)
        {
            Scene = scene;

            if (_runTimer == null)
            {
                _runTimer = new DispatcherTimer();
                _runTimer.Interval = TimeSpan.FromMilliseconds(Constans.RunInterval);
                _runTimer.Tick += _runTimer_Tick;
                _runTimer.Start();
            }
            // כך נרשמים לאירוע במקלדת
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
        }

        private void CoreWindow_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            if (GameEvent.OnKeyUp != null)
            {
                GameEvent.OnKeyUp(args.VirtualKey);
            }
        }

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (GameEvent.OnKeyDown != null)
            {
                GameEvent.OnKeyDown(args.VirtualKey);
            }
        }

        /// <summary>
        ///OnRun הפעוךה מתבצעת בתדירות מסויימת ללא הפסקה ומדליקה אירוע בשם 
        /// </summary>
        private void _runTimer_Tick(object sender, object e)
        {
            if (GameEvent.OnRun != null)
            {
                GameEvent.OnRun();
            }
        }
        public void Start()
        {
            Scene.init(); // החזרת כל האובייקטים למיקומם ההתחלתי
            _runTimer.Start(); // OnRun הפעולה מפעילה אירוע ללא הפסקה
            //_clockTimer.Start();
            GameState = GameState.Started;
        }
        public void Pause()
        {
            _runTimer.Stop();
            //_clockTimer.Stop();
            GameState = GameState.Paused;
        }
        public void Resume()
        {
            _runTimer.Start();
            //_clockTimer.Start();
            GameState = GameState.Started;
        }
        public bool GameOver()
        {
            if (GameState != GameState.GameOver)
            {
                GameState = GameState.GameOver;
                _runTimer.Stop();
                return true;
            }
            return false;
        }
    }
}
