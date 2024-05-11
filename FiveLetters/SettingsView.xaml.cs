using CommunityToolkit.Maui.Views;
using FiveLetters.ViewModel;

namespace FiveLetters;

public partial class SettingsView : Popup
{
	public SettingsView(SettingsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }


}