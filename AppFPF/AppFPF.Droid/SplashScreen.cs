using Android.App;
using Android.OS;

namespace AppFPF.Droid
{
    [Activity(Label = "SplashScreen", MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
        }
    }
}