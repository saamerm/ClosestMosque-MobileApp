using System;
using Xamarin.Forms;
using XLabs.Platform.Device;
using XLabs.Platform;
using XLabs.Ioc;
using XLabs.Platform.Services.Geolocation;
namespace ToTheMasjid
{
	public class App : Application
	{
		public App()
		{
			var oGeolocator = Resolver.Resolve<IGeolocator>(); // Resolve the Geolocator over the resolver
			GoToMainPage();
		}

		private static void GoToMainPage()
		{
			Current.MainPage = new MasjidTabbedPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
