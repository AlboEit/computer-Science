using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Imaging;

namespace Arcanoid.GameObjects
{
    public abstract class GameObject
    {
        protected double _X;
        protected double _Y;

        protected double _placeX;
        protected double _placeY;

        public Image Image { get; set; }
        protected string _filename;

        public double Height => Image.ActualHeight;
        public double Width => Image.ActualWidth;

        public virtual Rect Rect => new Rect(_X, _Y, Width, Height);

        public bool Collisional { get; set; } = true;// אפשר להתנגש בו , לא שקוף
        protected Scene _scene;//זירת המשחק

        /// <summary>
        /// The constractur builds a basic object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="placeX"></param>
        /// <param name="placeY"></param>
        /// <param name="image"></param>
        /// <param name="filename"></param>
        /// <param name="collisional"></param>
        /// <param name="scene"></param>
        protected GameObject(Scene scene, string filename, double placeX, double placeY)
        {
            _X = placeX;
            _Y = placeY;
            _placeX = placeX;
            _placeY = placeY;
            Image = new Image();
            _filename = filename;
            _scene = scene;
            Image = new Image();
            SetImage(filename);
            Render();
        }

        public virtual void Render() 
        {
            Canvas.SetLeft(Image, _X);
            Canvas.SetTop(Image, _Y);
            
        }
        protected void SetImage(string filename)
        {
            Image.Source = new BitmapImage(new Uri($"ms-appx:///Assets/{filename}"));
        }

        public virtual void init()
        {
            _X= _placeX;
            _Y= _placeY;
        }
        public virtual void Collide(GameObject g)
        { 
        }

    }
}
