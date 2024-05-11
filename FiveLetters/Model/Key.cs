using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLetters.Model
{
    public partial class Key:ObservableObject
    {
        
        [ObservableProperty]
        private char keyCharacter;

        [ObservableProperty]
        private Color keyBgColor;

        [ObservableProperty]
        private Color keyTextColor;
    }
}
