using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
// New Xlabs
using XLabs.Ioc; // Using for SimpleContainer
using XLabs.Platform.Services.Geolocation; // Using for Geolocation 
using XLabs.Platform.Device; // Using for Display
// End new Xlabs

namespace ToTheMasjid.Droid
{
	[Activity(Label = "ToTheMasjid.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			// New Xlabs
			var container = new SimpleContainer();
			container.Register<IDevice>(t => AndroidDevice.CurrentDevice); 
			container.Register<IGeolocator, Geolocator>(); 
			Resolver.SetResolver(container.GetResolver()); // Resolving the services																			     
			// End new Xlabs

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}
	}
}
