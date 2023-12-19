using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using GameEngine.GameServices;
using Windows.UI.Xaml.Controls;

namespace Arcanoid.GameObjects
{
    public class Brick:GameObject
    {
        public enum BrickType
        {
            Green = 0,Pink = 1,Yellow = 2
        }
        private BrickType _brickType;

         public Brick(Scene scene , BrickType brickType, double width, double placeX, double placeY) : base(scene, string.Empty, placeX, placeY)
        {
            Image.Width = width;
            Image.Height = width;
            _brickType = brickType;
            SetImage();
            
        }

        private void SetImage()
        {
            switch (_brickType)
            {
                case BrickType.Green:
                    base.SetImage("Brick/Brick_Green.png");
                    break;
                case BrickType.Pink:
                    base.SetImage("Assets/Brick/Brick_Pink.jpg");
                    break;
                case BrickType.Yellow:
                    base.SetImage("Assets/Brick/Brick_Yellow.jpg");
                    break;
            }
        }

        public void ChangeBrick(GameObject g)
        { }
    }
}
