using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.Objects;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using static TrafficLights.Objects.TrafficL;

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
            Events.OnChangeState += SetState; //מעכשיו החייה מקשיבה לאירוע. הרשמה לאירוע
        }
        /// <summary>
        /// פעולת תגובה לאירוע מצד החייה
        /// </summary>
        /// <param name="state"> המצב העדכני של הרמזור</param>
        private void SetState(TrafficLightState state)// זאת הפעולה של תגובת החיות לשינוי הרמזור
        {
            switch (state)
            {
                case TrafficLightState.Red:
                    _CharacterState = CharacterStateType.standing; 
                    break;
                case TrafficLightState.green:
                    _CharacterState = CharacterStateType.going;
                    break;
                case TrafficLightState.yellow:
                    _CharacterState = CharacterStateType.ready; 
                    break;
            }
            MatchGifToState();
        }

        protected virtual void MatchGifToState()
        {
            
        }
    }
}
