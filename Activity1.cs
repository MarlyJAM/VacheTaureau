using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace VacheTaureau
{
    [Activity(Label = "Activity1", MainLauncher = true)]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.layout1);
            Intent i = new Intent(this, typeof(MainActivity));
            EditText et1 = FindViewById<EditText>(Resource.Id.editText1);
            string nom = et1.Text;
            Button b1 = FindViewById<Button>(Resource.Id.button1);
            b1.Click += delegate
            {
                i.PutExtra("Nom", et1.ToString());
                i.PutExtra("Complexite", 5);
                StartActivity(i);
            };
            Button b2 = FindViewById<Button>(Resource.Id.button2);
            b2.Click += delegate
            {
                i.PutExtra("Nom", et1.ToString());
                i.PutExtra("Complexite", 6);
                StartActivity(i);
            };
            Button b3 = FindViewById<Button>(Resource.Id.button3);
            b3.Click += delegate
            {
                i.PutExtra("Nom", et1.ToString());
                i.PutExtra("Complexite", 7);
                StartActivity(i);
            };
        }
    }
}