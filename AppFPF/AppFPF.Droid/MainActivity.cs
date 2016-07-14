using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using AppFPF.Models;
using AppFPF.Service;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace AppFPF.Droid
{
    [Activity(Label = "AppFPF.Droid", Icon = "@drawable/icon", Theme = "@style/Base.Theme.Design")]
    public class MainActivity : AppCompatActivity
    {
        private Team team;
        private ListView PlayersLvw;

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //  Get a reference to player's list view
            PlayersLvw = FindViewById<ListView>(Resource.Id.PlayerListView);

            //  Set the toolbar with a title
            SupportToolbar toolbar = FindViewById<SupportToolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Federación Peruana de Fútbol";

            //  Get data from web service
            team = await APIService.GetTeam();

            //  Fill up the list view
            PlayerAdapter adapter = new PlayerAdapter(team.PlayersList, this);
            PlayersLvw.Adapter = adapter;

            //  Manage item click event
            PlayersLvw.ItemClick += PlayersLvw_ItemClick;
        }

        private void PlayersLvw_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //  Get selected player id
            var selectedID = team.PlayersList[e.Position].ID;

            //  Navigate to player page
            Intent i = new Intent(this, typeof(PlayerResumeActivity));
            i.PutExtra("playerID", selectedID);
            StartActivity(i);
        }
    }
}