using System;
using Xamarin.Forms;

namespace ToTheMasjid
{
	public class MasjidTabbedPage:TabbedPage
	{
		public MasjidTabbedPage()
		{
			Title = "TabbedPage";
			BackgroundColor = Color.FromRgb(121, 191, 48);
			BarBackgroundColor = Color.FromRgb(98, 182, 15);
			BarTextColor = Color.White;
			//var embeddedImage = new Image { Aspect = Aspect.AspectFit };
			//embeddedImage.Source = ImageSource.FromResource("Resources.Images.rukuposture.png");
			Children.Add(new NavigationPage(new MosquesPage())
			{
				BackgroundColor = Color.White,
				BarBackgroundColor = Color.FromRgb(121, 191, 48),
				BarTextColor = Color.White,
				Title = "Mosques",
				Icon = "Pray32.png" 
				//TODO: Change Icons 
			});
			Children.Add(new NavigationPage(new NotificationsPage())
			{
				BackgroundColor = Color.White,
				BarBackgroundColor = Color.FromRgb(121, 191, 48),
				//BarBackgroundColor = Color.FromRgb(137, 188, 75), equivalent
				BarTextColor = Color.White,
				Title = "Notifications",
				Icon = "Pray32.png" 
				//TODO: Change Icons 
			});
			Children.Add(new NavigationPage(new AboutPage())
			{
				BackgroundColor = Color.White,
				BarBackgroundColor = Color.FromRgb(121, 191, 48),
				BarTextColor = Color.White,
				Title = "About",
				Icon = "Pray32.png" 
				//TODO: Change Icons 
			});
		}
	}
}
