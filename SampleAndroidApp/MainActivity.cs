using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using SampleAndroidApp.PCL;
using System.Collections.Generic;
using System;

namespace SampleAndroidApp
{
    [Activity(Label = "SampleAndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        CountriesViewModel viewModel;
        List<Countries> countries = new List<Countries>();
        protected async override void OnCreate(Bundle bundle)
        {
            viewModel = new CountriesViewModel();
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var listView = FindViewById<ListView>(Resource.Id.CountriesListView);
            var coutriesList = await viewModel.GetCountriesData();
            foreach (var item in coutriesList)
            {
                countries.Add(new Countries { CountryCode = item.Key, CountryName = item.Value });
            }
            listView.Adapter = new HomeScreenAdapter(this, countries);
        } 
    }

    public class HomeScreenAdapter : BaseAdapter<List<Countries>>
    {
        List<Countries> items;
        Activity context;
        public HomeScreenAdapter(Activity context, List<Countries> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override List<Countries> this[int position]
        {
            get {  return items; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;  
            if (view == null) 
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].CountryCode + " - " + items[position].CountryName;
            return view;
        }
    }
}

