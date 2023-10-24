using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace TrafficLight.Objects
{
    internal class Character
    {
        public enum CharacterStateType     
        {
            standing,ready,going
        }
        private Image _imageCharacter;
        protected BitmapImage _bitmapImage;
        protected CharacterStateType _CharacterState;

        public Character(Image imageCharacter)
        {
            _CharacterState= CharacterStateType.standing;
            _imageCharacter = imageCharacter;
            _bitmapImage = new BitmapImage();
            _imageCharacter.Source = _bitmapImage;
            MatchGifToState();
        }

        protected virtual void MatchGifToState()
        {
            
        }
    }
}
