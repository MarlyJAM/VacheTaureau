using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Views;
using Android.Widget;
using System;
using Android.Content;
using Android.Text;

namespace VacheTaureau
{
    [Activity(Label = "@string/app_name", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        public string val;
        public TextView tv7;
        public int cplx;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            cplx = Intent.GetIntExtra("Complexite", 5);
            int minVal = (int)Math.Pow(10, cplx - 1);
            int maxVal = (int)Math.Pow(10, cplx) - 1;
            Random r = new Random();
            int valeur = r.Next(maxVal - minVal) + minVal;
            val = valeur.ToString();
            tv7 = FindViewById<TextView>(Resource.Id.textView7);
            TextView tv14 = FindViewById<TextView>(Resource.Id.textView14);
            tv14.Text = "Complexité: " + cplx;
            EditText et1 = FindViewById<EditText>(Resource.Id.editText1);
            et1.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(cplx) });
            TextView tv8 = FindViewById<TextView>(Resource.Id.textView8);
            LinearLayout ll3 = FindViewById<LinearLayout>(Resource.Id.linearLayout3);
            EditText et2 = FindViewById<EditText>(Resource.Id.editText2);
            et2.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(cplx) });
            TextView tv9 = FindViewById<TextView>(Resource.Id.textView9);
            LinearLayout ll4 = FindViewById<LinearLayout>(Resource.Id.linearLayout4);
            EditText et3 = FindViewById<EditText>(Resource.Id.editText3);
            et3.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(cplx) });
            TextView tv10 = FindViewById<TextView>(Resource.Id.textView10);
            LinearLayout ll5 = FindViewById<LinearLayout>(Resource.Id.linearLayout5);
            EditText et4 = FindViewById<EditText>(Resource.Id.editText4);
            et4.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(cplx) });
            TextView tv11 = FindViewById<TextView>(Resource.Id.textView11);
            LinearLayout ll6 = FindViewById<LinearLayout>(Resource.Id.linearLayout6);
            EditText et5 = FindViewById<EditText>(Resource.Id.editText5);
            et5.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(cplx) });
            TextView tv12 = FindViewById<TextView>(Resource.Id.textView12);
            LinearLayout ll7 = FindViewById<LinearLayout>(Resource.Id.linearLayout7);
            EditText et6 = FindViewById<EditText>(Resource.Id.editText6);
            et6.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(cplx) });
            TextView tv13 = FindViewById<TextView>(Resource.Id.textView13);
            LinearLayout ll8 = FindViewById<LinearLayout>(Resource.Id.linearLayout8);
            Button b1 = FindViewById<Button>(Resource.Id.button1);
            b1.Click += delegate
            {
                if (ll7.Visibility == ViewStates.Visible)
                    testerVal2(et6, tv13);
                else if (ll6.Visibility == ViewStates.Visible)
                    testerVal(5, et5, tv12, ll7);
                else if (ll5.Visibility == ViewStates.Visible)
                    testerVal(4, et4, tv11, ll6);
                else if (ll4.Visibility == ViewStates.Visible)
                    testerVal(3, et3, tv10, ll5);
                else if (ll3.Visibility == ViewStates.Visible)
                    testerVal(2, et2, tv9, ll4);
                else
                    testerVal(1, et1, tv8, ll3);
            };
            Button b2 = FindViewById<Button>(Resource.Id.button2);
            b2.Click += delegate
            {
                r = new Random();
                minVal = (int)Math.Pow(10, cplx - 1);
                maxVal = (int)Math.Pow(10, cplx) - 1;
                valeur = r.Next(maxVal - minVal) + minVal;
                val = valeur.ToString();
                tv7.Text = "";
                et1.Text = "";
                et1.Enabled = true;
                tv8.Text = "";
                et2.Text = "";
                et2.Enabled = true;
                tv9.Text = "";
                et3.Text = "";
                et3.Enabled = true;
                tv10.Text = "";
                et4.Text = "";
                et4.Enabled = true;
                tv11.Text = "";
                et5.Text = "";
                et5.Enabled = true;
                tv12.Text = "";
                et6.Text = "";
                et6.Enabled = true;
                tv13.Text = "";
                ll3.Visibility = ViewStates.Invisible;
                ll4.Visibility = ViewStates.Invisible;
                ll5.Visibility = ViewStates.Invisible;
                ll6.Visibility = ViewStates.Invisible;
                ll7.Visibility = ViewStates.Invisible;
            };
        }
        public void testerVal(int essai, EditText et, TextView tv, LinearLayout ll)
        {
            string chaine = et.Text;
            string resultat = "";
            if (chaine.Length == cplx)
            {
                for (int i = 0; i < chaine.Length; i++)
                {
                    if (val.IndexOf(chaine.Substring(i, 1)) == -1)
                        resultat += "_";
                    else
                    {
                        if (chaine.Substring(i, 1) == val.Substring(i, 1))
                            resultat += "T";
                        else
                            resultat += "V";
                    }
                }
                tv.Text = resultat;
                et.Enabled = false;
                if (chaine == val)
                {
                    Toast.MakeText(Application.Context, "Bravo! Vous avez trouvé le nombre", ToastLength.Long).Show();
                    tv7.Text = "Le nombre caché: " + val;
                }
                else
                {
                    Toast.MakeText(Application.Context, "Passez à l'essai suivant", ToastLength.Long).Show();
                    ll.Visibility = ViewStates.Visible;
                    essai++;
                }
            }
            else
                Toast.MakeText(Application.Context, "Vous devez saisir des nombres avec " + cplx + " chiffres", ToastLength.Long).Show();
        }
        public void testerVal2(EditText et, TextView tv)
        {
            string chaine = et.Text;
            string resultat = "";
            if (chaine.Length == cplx)
            {
                for (int i = 0; i < chaine.Length; i++)
                {
                    if (val.IndexOf(chaine.Substring(i, 1)) == -1)
                        resultat += "_";
                    else
                    {
                        if (chaine.Substring(i, 1) == val.Substring(i, 1))
                            resultat += "T";
                        else
                            resultat += "V";
                    }
                }
                tv.Text = resultat;
                et.Enabled = false;
                tv7.Text = "Le nombre caché: " + val;
                if (chaine == val)
                    Toast.MakeText(Application.Context, "Bravo! Vous avez trouvé le nombre", ToastLength.Long).Show();
                else
                    Toast.MakeText(Application.Context, "Vous avez épuisé tous les essais", ToastLength.Long).Show();
            }
            else
                Toast.MakeText(Application.Context, "Vous devez saisir des nombres avec " + cplx + " chiffres", ToastLength.Long).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}