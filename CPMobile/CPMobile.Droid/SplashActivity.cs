using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CPMobile.Droid
{
    [Activity(Label = "CPMobile", Icon = "@drawable/icon",Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            System.Threading.Thread.Sleep(1000); //Let's wait awhile...
            this.StartActivity(typeof(MainActivity));
            // Create your application here
        }
    }
}