using Android.Media;
using Android.OS;
using FiveLetters.ViewModel;
using Java.Lang;

namespace FiveLetters;

public partial class MainPage : ContentPage
{


	public MainPage(GameViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}

