using FiveLetters.Helpers;
using FiveLetters.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLetters.Services
{
    public class UserStatsService : IUserStatsSevice
    {
        public UserStats CalculateUserStats(UserStats userStats,int guessCounter)
        {
            userStats.TotalGamesPlayed++;
            if (userStats.IsLastGameWin)
            {
                userStats.TotalGamesWon++;
                userStats.CurrentStreak++;
                userStats.data[--guessCounter]++;
            }
            else
            {
                if (userStats.MaxStreak < userStats.CurrentStreak)
                    userStats.MaxStreak = userStats.CurrentStreak;
                userStats.CurrentStreak = 0;
            }
            userStats.WinPercentage = Convert.ToInt32(((double)userStats.TotalGamesWon / userStats.TotalGamesPlayed) * 100);
            return userStats;
        }

        public bool ClearAllStats<T>(string name)
        {
            return SecureStorage.Remove(name);
        }

        public bool SetUserStats<T>(T data,string name)
        {
            var serialdata=JsonConvert.SerializeObject(data);
            return SecureStorage.SetAsync(name, serialdata).IsCompletedSuccessfully;
        }

        public T GetUserStats<T>(string name)
        {
            var data = SecureStorage.GetAsync(name).Result;
            if(data != null)
                return JsonConvert.DeserializeObject<T>(data);
            return default(T);
        }
    }
}
