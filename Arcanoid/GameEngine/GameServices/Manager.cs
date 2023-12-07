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
        public static DispatcherTimer _runTimer;//הטיימר יפעיל ללא הפסקה אירוע OnRun
        public static GameEvent gameEvent { get; } = new GameEvent();


        public static GameState GameState { get; set; } = GameState.Loaded;


        public Manager(Scene scene) 
        {
            Scene = scene;
            if (_runTimer == null)
            {
                _runTimer = new DispatcherTimer();
                _runTimer.Interval = TimeSpan.FromMilliseconds(Constans.RunInterval);
                _runTimer.Tick += _runTimer_Tick; ;
                _runTimer.Start();
                
            }
            //כף נרשמים לשימוש במיקלדת
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown; ;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
        }

        private void CoreWindow_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            if (gameEvent.OnKeyUp!= null) 
            {
                gameEvent.OnKeyUp(args.VirtualKey);
            }
        }

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (gameEvent.OnKeyDown != null)
            {
                gameEvent.OnKeyDown(args.VirtualKey);
            }
        }
        public void Start() 
        {
            Scene.init();
            _runTimer.Start();
            GameState = GameState.Started;
        }

        public void pause() 
        {
            _runTimer.Stop();
            GameState = GameState.Paused;
        }
        public void Resume() 
        {
            _runTimer.Start();
            GameState = GameState.Started;
        }


        public static bool GameOver()
        {
            if (GameState != GameState.GameOver)
            {
                GameState = GameState.GameOver;
                _runTimer.Stop();
                return true;


            }
            return false;
        }

        /// <summary>
        /// הפעןלה מתבצעת בדירות מסוימת ללא הפסקה ומדליקה אירוע בשם OnRun
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _runTimer_Tick(object sender, object e)
        {
            if(gameEvent.OnRun!=null)
            {
                gameEvent.OnRun();
            }
        }
    }
}
