using FiveLetters.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLetters.Helpers
{
    public static class CustomColors
    {
        public static Color SeaGreen { get
            {
                return Color.FromArgb("#09b492");
            } 
        }

        public static Color LightYellow { get 
            {
                return Color.FromArgb("#f5b613");
            } 
        }

        public static Color Grayish { get 
            {
                return Color.FromArgb("#343554");
            } 
        }

        public static Color Blackish { get 
            {
                return Color.FromArgb("#a3a3ad");
            } 
        }

        //public static UserStats StatsStorage { get; set; }
    }
}
