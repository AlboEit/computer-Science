using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using static TrafficLight.Objects.Character;
using Windows.UI.Xaml.Media.Imaging;

namespace TrafficLight.Objects
{
    internal class Warrior:Character
    {
        public Warrior(Image imageCharacter) :base(imageCharacter)
        {
        }

        protected override void MatchGifToState()
        {
            switch (_CharacterState)
            {
                case CharacterStateType.standing:
                    _bitmapImage.UriSource = new Uri("ms-appx:///Assets/Animals/Cat/Idle-Left.gif");
                    break;
                case CharacterStateType.ready:
                    _bitmapImage.UriSource = new Uri("ms-appx:///Assets/Animals/Cat/Jump-Left.gif");
                    break;
                case CharacterStateType.going:
                    _bitmapImage.UriSource = new Uri("ms-appx:///Assets/Animals/Cat/Run-Left.gif");
                    break;
            }
        }
    }
}
