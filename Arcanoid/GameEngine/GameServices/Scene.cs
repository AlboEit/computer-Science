using Arcanoid.GameObjects;
using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls.Background;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace GameEngine.GameServices
{
    public abstract class Scene:Canvas
    {
        private List<GameObject> _gameObjects = new List<GameObject>();
        protected List<GameObject> _gameObjectSnapshot => _gameObjects.ToList();

        public double Ground { get; set; }





        public void checkCollision()
        {
            foreach (var gameObject in _gameObjectSnapshot)
            {
                if (gameObject.Collisional)
                {
                    var otherObject = _gameObjectSnapshot.FirstOrDefault(g => !ReferenceEquals(g, gameObject) 
                    && g.Collisional && !RectHelper.Intersect(g.Rect, gameObject.Rect).IsEmpty);
                    if (otherObject != null)
                    {
                        gameObject.Collide(otherObject);
                    }
                }
                
            }
        }
        public Scene() 
        {
            Manager.GameEvent.OnRun += Run;
        }
        public void Run()
        {
            foreach (var obj in _gameObjects)
            {
                if (obj is GameMovingObject)
                {
                    obj.Render();
                }
            }
        }

        public void init() 
        {
            foreach (GameObject obj in _gameObjectSnapshot) 
            {
                obj.init();
            }
        }
        public void RemoveAllObject() 
        {
            foreach (GameObject gameObject in _gameObjectSnapshot) 
            {
                RemoveObject(gameObject);
            }
        }

        public void RemoveObject(GameObject gameObject) 
        {
            if (_gameObjects.Contains(gameObject)) 
            {
                _gameObjects.Remove(gameObject);
                Children.Remove(gameObject.Image);
            }
        }
        public void AddObject(GameObject gameObject)
        { 
            _gameObjects.Add(gameObject);
            Children.Add(gameObject.Image);
        }
    }
}
