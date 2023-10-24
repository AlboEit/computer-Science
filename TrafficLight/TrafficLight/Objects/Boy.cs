using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TrafficLight.Objects
{
    internal class Boy : Character
    {
        public Boy(Image imageCharacter) : base(imageCharacter)
        {
        }
        protected override void MatchGifToState()
        {
            switch (_CharacterState)
            {
                case CharacterStateType.standing:
                    _bitmapImage.UriSource = new Uri("ms-appx:///Assets/Animals/Dog/Idle-right.gif");
                    break;
                case CharacterStateType.ready:
                    _bitmapImage.UriSource = new Uri("ms-appx:///Assets/Animals/Dog/Jump-right.gif");
                    break;
                case CharacterStateType.going:
                    _bitmapImage.UriSource = new Uri("ms-appx:///Assets/Animals/Dog/Run-right.gif");
                    break;

            }
        }
    }
}
