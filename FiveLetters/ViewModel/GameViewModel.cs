using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FiveLetters.Helpers;
using FiveLetters.Model;
using FiveLetters.Services;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace FiveLetters.ViewModel;

public partial class GameViewModel : ObservableObject
{
    // 0 - 5 
    int rowIndex;
    // 0 - 4
    int columnIndex;
    int guessCounter;
    char[] correctAnswer;

    [ObservableProperty]
    private WordRow[] rows;
    [ObservableProperty]
    private char guessCharacter;
    [ObservableProperty]
    char deleteCharacter;
    private readonly UserStatsService _statsService;
    [ObservableProperty]
    bool isGuessEnabled;
    [ObservableProperty]
    string guessButtonText;

    private readonly WordService wordService;

    [ObservableProperty]
    UserStats userStats;

    public char[] KeyboardRow1 { get; }
    public char[] KeyboardRow2 { get; }
    public char[] KeyboardRow3 { get; }
    public ObservableCollection<Key> KeyboardList1 { get; set; } = new();
    public ObservableCollection<Key> KeyboardList2 { get; set; } = new();
    public ObservableCollection<Key> KeyboardList3 { get; set; } = new();

    public GameViewModel(WordService wordService, UserStatsService statsService)
    {

        this.wordService = wordService;
        _statsService = statsService;

        //ResetGame(true);

        //Rows = new WordRow[6]
        //{
        //    new WordRow(),
        //    new WordRow(),
        //    new WordRow(),
        //    new WordRow(),
        //    new WordRow(),
        //    new WordRow()
        //};

        //var newWord = wordService.GetRandomWord().ToUpper();
        //correctAnswer = newWord.ToCharArray();

        //UserStatsInit();
        KeyboardRow1 = "QWERTYUIOP".ToCharArray();
        KeyboardRow2 = "ASDFGHJKL".ToCharArray();
        KeyboardRow3 = "ZXCVBNM".ToCharArray();
        //GuessButtonText = "GUESS";

        ResetGame(true);

        //SetupKeyboard("constructor");

        IsGuessEnabled = false;
        GuessCharacter = '>';
        deleteCharacter = '<';
    }

    void ResetGame(bool isReset)
    {
        if (isReset)
        {
            Rows = new WordRow[6]
                {
                        new WordRow(),
                        new WordRow(),
                        new WordRow(),
                        new WordRow(),
                        new WordRow(),
                        new WordRow(),
                };
            SetupKeyboard("reset");
            correctAnswer = wordService.GetRandomWord().ToUpper().ToCharArray();
            rowIndex = 0;
            columnIndex = 0;
            guessCounter = 0;
            GuessButtonText = "GUESS";
        }
        else
        {
            GuessButtonText =  "NEXT";
        }
    }


    void SetColor(Key findKey, Letter leter)
    {
        if (findKey.KeyBgColor.Equals(CustomColors.SeaGreen))
        {
            return;
        }
        else
        {
            if (findKey.KeyBgColor.Equals(CustomColors.LightYellow))
            {
                if (leter.Color.Equals(CustomColors.SeaGreen))
                {
                    findKey.KeyBgColor = leter.Color;
                    findKey.KeyTextColor = Colors.White;
                }
                else
                {
                    return;
                }
            }
            else
            {
                findKey.KeyBgColor = leter.Color;
                findKey.KeyTextColor = Colors.White;
            }
        }
    }

    void AddColortoKey(Letter leter)
    {
        if (KeyboardList1.Any(x => x.KeyCharacter == leter.Input))
        {
            var findKey = KeyboardList1.FirstOrDefault(x => x.KeyCharacter == leter.Input);
            SetColor(findKey, leter);
        }
        else if (KeyboardList2.Any(x => x.KeyCharacter == leter.Input))
        {
            var findKey = KeyboardList2.FirstOrDefault(x => x.KeyCharacter == leter.Input);
            SetColor(findKey, leter);
        }
        else
        {
            var findKey = KeyboardList3.FirstOrDefault(x => x.KeyCharacter == leter.Input);
            SetColor(findKey, leter);
        }
    }

    public bool Validate(WordRow row, char[] correctAnswer)
    {
        int count = 0;
        var wordle = correctAnswer.ToList();
        var checkWordle = correctAnswer.ToList();
        var guess = new List<Letter>();

        row.Letters.ToList().ForEach(x =>
        {
            guess.Add(new Letter
            {
                Input = x.Input,
                Color = CustomColors.Grayish,
                LetterTextColor = CustomColors.Blackish
            });
        });

        int index = 0;
        foreach (var item in guess)
        {
            if (item.Input == wordle[index])
            {
                item.Color = CustomColors.SeaGreen;
                item.LetterTextColor = Colors.White;
                checkWordle.Remove(item.Input);
                count++;
            }
            index++;
        }

        guess.ForEach(x =>
        {
            if (checkWordle.Contains(x.Input) && !x.Color.Equals(CustomColors.SeaGreen))
            {
                x.Color = CustomColors.LightYellow;
                x.LetterTextColor = Colors.White;
                checkWordle.Remove(x.Input);
            }
        });

        int i = 0;
        foreach (var item in row.Letters)
        {
            item.Color = guess[i].Color;
            item.LetterTextColor = guess[i].LetterTextColor;
            AddColortoKey(guess[i]);
            i++;
        }

        return count == 5;
    }



    public async Task Enter()
    {
        if (GuessButtonText.ToUpper().Equals("NEXT"))
        {
            ResetGame(isReset: true);
            GuessButtonText = "GUESS";
            return;
        }

        if (columnIndex != 5)
        {
            await App.Current.MainPage.DisplayAlert("Insufficient!", "Please fill the word!", "OK");
            return;
        }

        int i = 0;
        char[] tempArray = new char[5];
        foreach (var item in Rows[rowIndex].Letters)
        {
            tempArray[i++] = item.Input;
        }

        var guess = String.Concat(tempArray);

        var isExists = wordService.IsWordExists(guess.ToLower());
        if (!isExists)
        {
            await App.Current.MainPage.DisplayAlert("Incorrect Word!", "Please fill the right words!", "OK");
            return;
        }



        guessCounter++;
        var isCorrect = Validate(Rows[rowIndex], correctAnswer);
        //if(UserStats == null)
        //{
        //    UserStatsInit();
        //}
        var rightWord = string.Concat(correctAnswer).ToLower();

        if (isCorrect)
        {
            UserStats.IsLastGameWin = true;
            UserStats.Level++;
            UserStats = _statsService.CalculateUserStats(UserStats, guessCounter);
            string action = await App.Current.MainPage.DisplayActionSheet(
                "Brilliant! You Found the Correct Word",
                "Close",
                null,
                "Know More About This Word",
                "Play Next Game");
            HandleAction(action);
            return;
        }

        if (rowIndex == 5)
        {
            UserStats.IsLastGameWin = false;
            UserStats = _statsService.CalculateUserStats(UserStats, guessCounter);
            string action = await App.Current.MainPage.DisplayActionSheet(
                $"Game Over! the correct word is {rightWord}",
                "Close",
                null,
                "Know More About This Word",
                "Play Next Game");
            HandleAction(action);
            return;
        }
        else
        {
            rowIndex++;
            columnIndex = 0;
        }

    }

    void HandleAction(string action)
    {
        var rightWord = string.Concat(correctAnswer).ToLower();
        switch (action)
        {
            case "Know More About This Word":
                Openbrowser(rightWord);
                break;
            case "Play Next Game":
                ResetGame(isReset: true);
                break;
            case "Close":
                ResetGame(isReset: false);
                break;
            default:
                break;
        }
    }

    async void Openbrowser(string word)
    {
        try
        {
            Uri uri = new Uri($"https://www.merriam-webster.com/dictionary/{word}");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            return;
        }
    }

    [ICommand]
    public void EnterLetter(char enteredKey)
    {
        if (columnIndex == 4)
        {
            IsGuessEnabled = true;
        }

        if (enteredKey == '>')
        {
            Enter();
            return;
        }

        if (enteredKey == '<')
        {
            if (columnIndex == 0)
                return;
            columnIndex--;
            Rows[rowIndex].Letters[columnIndex].Input = ' ';

            return;
        }

        if (columnIndex == 5)
            return;

        Rows[rowIndex].Letters[columnIndex].Input = enteredKey;
        columnIndex++;
    }

    [ICommand]
    public void OpenSettings()
    {
        App.Current.MainPage.ShowPopupAsync(new UserStatsPopup(new UserStatsViewModel(UserStats)));
        //App.Current.MainPage.ShowPopupAsync(new SettingsView(new SettingsViewModel()));
    }

    [ICommand]
    public void OpenHelpPage()
    {
        App.Current.MainPage.ShowPopupAsync(new HelpPage(new HelpPageModel()));
    }




    void SetupKeyboard(string actionName)
    {
        //TODO: Optimize for Reset

        KeyboardList1.Clear();
        KeyboardList2.Clear();
        KeyboardList3.Clear();

        KeyboardRow1.ToList().ForEach(x =>
        {
            KeyboardList1.Add(new Key
            {
                KeyCharacter = x,
                KeyBgColor = Color.FromRgba(216, 217, 219, 255),
                KeyTextColor = Colors.Black
            });
        });

        KeyboardRow2.ToList().ForEach(x =>
        {
            KeyboardList2.Add(new Key
            {
                KeyCharacter = x,
                KeyBgColor = Color.FromRgba(216, 217, 219, 255),
                KeyTextColor = Colors.Black
            });
        });

        KeyboardRow3.ToList().ForEach(x =>
        {
            KeyboardList3.Add(new Key
            {
                KeyCharacter = x,
                KeyBgColor = Color.FromRgba(216, 217, 219, 255),
                KeyTextColor = Colors.Black
            });
        });
    }


    public void UserStatsInit()
    {
        UserStats = _statsService.GetUserStats<UserStats>("userstats");
        if (UserStats == null)
        {
            UserStats = new UserStats
            {
                Level = 1,
                TotalGamesPlayed = 0,
                WinPercentage = 0,
                CurrentStreak = 0,
                MaxStreak = 0,
                data = new List<double> { 0, 0, 0, 0, 0, 0 },
                labels = new List<string> { "1", "2", "3", "4", "5", "6" }
            };
        }
    }

    public void UserStatsSave()
    {
        _statsService.SetUserStats<UserStats>(UserStats, "userstats");
    }
}

