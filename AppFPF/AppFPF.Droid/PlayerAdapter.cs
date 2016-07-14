using Android.Content;
using Android.Views;
using Android.Widget;
using AppFPF.Models;
using Square.Picasso;
using System.Collections.Generic;

namespace AppFPF.Droid
{
    public class PlayerAdapter : BaseAdapter<Player>
    {
        private List<Player> list;
        private Context context;

        public PlayerAdapter(List<Player> _list, Context _context)
        {
            list = _list;
            context = _context;
        }

        public override Player this[int position]
        {
            get
            {
                return list[position];
            }
        }

        public override int Count
        {
            get
            {
                return list.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = LayoutInflater.From(context).Inflate(Resource.Layout.PlayerAdapter, null);

            TextView name = view.FindViewById<TextView>(Resource.Id.player_name);
            TextView number = view.FindViewById<TextView>(Resource.Id.player_number);
            ImageView photo = view.FindViewById<ImageView>(Resource.Id.player_photo);

            //  Set values
            name.Text = list[position].Name;
            number.Text = list[position].Number.ToString();

            //  Load image from url
            Picasso.With(context).Load(list[position].Photo).Into(photo);

            return view;
        }
    }
}