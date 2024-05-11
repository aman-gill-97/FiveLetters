using CommunityToolkit.Maui.Views;
using FiveLetters.ViewModel;

namespace FiveLetters;

public partial class HelpPage : Popup
{
	public HelpPage(HelpPageModel viewModel)
	{
		InitializeComponent();
        //BindingContext = viewModel;
	}
}