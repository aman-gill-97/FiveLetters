using CommunityToolkit.Maui.Views;
using FiveLetters.ViewModel;

namespace FiveLetters;

public partial class SettingsPopup : Popup
{

    public SettingsPopup(UserStatsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}