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
                    base.SetImage("Brick/Brick_Pink.png");
                    break;
                case BrickType.Yellow:
                    base.SetImage("Brick/Brick_Yellow.png");
                    break;
            }
        }

        public void ChangeBrick(GameObject g)
        {
            switch (_brickType)
            { 
                case BrickType.Yellow:
                    _brickType=BrickType.Green;
                    SetImage();
                    break;
                case BrickType.Pink:
                    _brickType = BrickType.Yellow;
                    SetImage();
                    break; 
                case BrickType.Green:
                    _scene.RemoveObject(this);
                    return;
            }
        }
    }
}
