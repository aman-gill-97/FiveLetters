using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace FiveLetters;

[Activity(Label="Worzle", Icon = "@drawable/puzzle", Theme = "@style/Maui.SplashTheme", NoHistory =true, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
       
        base.OnCreate(savedInstanceState);
    }

    //override sa
   
}
