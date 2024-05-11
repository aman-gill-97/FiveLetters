using FiveLetters.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLetters.Services
{
    public interface IUserStatsSevice
    {
        T GetUserStats<T>(string name);
        bool SetUserStats<T>(T data, string name);
        bool ClearAllStats<T>(string name);
        UserStats CalculateUserStats(UserStats userStats,int guessCounter);
    }
}
