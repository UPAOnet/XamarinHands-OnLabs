using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using AppFPF.Models;
using AppFPF.Service;
using Square.Picasso;

namespace AppFPF.Droid
{
    [Activity(Label = "PlayerResumeActivity", Theme = "@style/Base.Theme.Design")]
    public class PlayerResumeActivity : AppCompatActivity
    {
        private Player currentPlayer;
        private TextView playerName;
        private TextView playerClub;
        private TextView playerNumber;
        private TextView playerPosition;
        private ImageView playerPhoto;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PlayerResume);

            //  Get references
            playerName = FindViewById<TextView>(Resource.Id.person_name);
            playerClub = FindViewById<TextView>(Resource.Id.player_club);
            playerNumber = FindViewById<TextView>(Resource.Id.player_number);
            playerPosition = FindViewById<TextView>(Resource.Id.player_position);
            playerPhoto = FindViewById<ImageView>(Resource.Id.person_photo);

            //  Get the ID parameter from previous activity
            var id = Intent.GetIntExtra("playerID", 0);

            //  Get player info
            currentPlayer = await APIService.GetPlayer(id);

            //  Fill up data
            playerName.Text = currentPlayer.Name;
            playerClub.Text = currentPlayer.Team;
            playerNumber.Text = currentPlayer.Number.ToString();
            playerPosition.Text = currentPlayer.Position;
            Picasso.With(this).Load(currentPlayer.Photo).Into(playerPhoto);
        }
    }
}