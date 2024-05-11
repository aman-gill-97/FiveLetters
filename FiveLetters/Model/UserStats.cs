using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLetters.Model
{
    public class UserStats
    {
        public int Level { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int WinPercentage { get; set; }
        public int CurrentStreak { get; set; }
        public int MaxStreak { get; set; }
        public int TotalGamesWon { get; set; }
        public bool IsLastGameWin { get; set; }
        public List<double> data { get; set; }
        public List<string> labels { get; set; }
    }
}
