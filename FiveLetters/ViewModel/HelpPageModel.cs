
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FiveLetters.ViewModel;

public partial class HelpPageModel : ObservableObject
{

	public HelpPageModel()
	{
		
	}

    [ICommand]
    public void OpenGame()
    {
        App.Current.MainPage.Navigation.PushAsync(new MainPage(new GameViewModel(new Services.WordService(), new Services.UserStatsService())));
    }
}