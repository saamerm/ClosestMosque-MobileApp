using System;

using Xamarin.Forms;

namespace ToTheMasjid
{
	public class App : Application
	{
		public App()
		{
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
