using Android.App;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using CPMobile.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(RootNavigationRenderer))]
namespace CPMobile.Droid
{
	public class RootNavigationRenderer : NavigationRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
		{
			base.OnElementChanged (e);

			RemoveAppIconFromActionBar ();
		}

		void RemoveAppIconFromActionBar()
		{
			
			var actionBar = ((Activity)Context).ActionBar;
			actionBar.SetIcon (new ColorDrawable(Color.Transparent.ToAndroid()));
		}
	}
}

