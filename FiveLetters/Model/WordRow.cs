using CommunityToolkit.Mvvm.ComponentModel;
using FiveLetters.Services;
using System.Collections.Generic;

namespace FiveLetters.Model;

public class WordRow
{
    public WordRow()
    {
        Letters = new Letter[5]
        {
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter()
        };
        
    }

    public Letter[] Letters { get; set; }

}

public partial class Letter : ObservableObject
{
    public Letter()
    {
        Color = Color.FromArgb("#e7f0f7");
        LetterTextColor = Colors.Black;
        BorderColor = Colors.LightGray;
    }

    [ObservableProperty]
    private char input;

    [ObservableProperty]
    private Color color;

    [ObservableProperty]
    private Color letterTextColor;

    [ObservableProperty]
    private Color borderColor;
}
