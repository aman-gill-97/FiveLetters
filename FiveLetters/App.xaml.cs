using FiveLetters.Helpers;
using FiveLetters.Services;
using FiveLetters.ViewModel;

namespace FiveLetters;

public partial class App : Application
{
    private readonly GameViewModel viewmodel;

    public App(MainPage page,UserStatsService statsService, GameViewModel viewModel)
	{
		InitializeComponent();
		MainPage = page;
        this.viewmodel = viewModel;
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);
        
        window.Created += Window_Created;
        window.Stopped += Window_Stopped;
        return window;
    }

    private void Window_Stopped(object sender, EventArgs e)
    {
        viewmodel.UserStatsSave();
    }

    private void Window_Created(object sender, EventArgs e)
    {
        viewmodel.UserStatsInit();
    }

}
