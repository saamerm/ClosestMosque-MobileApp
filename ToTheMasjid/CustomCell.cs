using System;
using Xamarin.Forms;

namespace ToTheMasjid
{
	public class CustomCell : ViewCell
	{
		public CustomCell()
		{
			// Create views with bindings for displaying each property.
			var mosqueNameLabel = new Label();
			mosqueNameLabel.SetBinding(Label.TextProperty, "name");
			var x = mosqueNameLabel.Width;
			var mosqueDistanceLabel = new Label(){Text="\t <1 mile"};

			var nextPrayerName = new Label();
			//birthdayLabel.SetBinding(Label.TextProperty,
			//new Binding("AsrTime", BindingMode.OneWay,
			//null, null, "Born {0:d}"));
			nextPrayerName.Text = "Next: Maghreb.";
			var image = new Image()
			{
				Source = "Pray32.png"
			};
			//boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

			var nextPrayerTime = new Label() { Text = "\t 2:15pm" };

			var midUpperStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children =
				{
					mosqueNameLabel,
					mosqueDistanceLabel
				}
			};
			var midLowerStack = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children =
				{
					nextPrayerName,
					nextPrayerTime
				}
			};
			var midWholeStack = new StackLayout()
			{
				VerticalOptions = LayoutOptions.Center,
				Spacing = 0,
				Children =
				{
					midUpperStack,
					midLowerStack
				}
			};
			var nextLabel = new Label()
			{
				Text = "\t >", 
				TextColor = Color.Silver
			};
			var nextPage = new StackLayout()
			{
				VerticalOptions = LayoutOptions.Center,
				Spacing = 2,
				Children =
				{
					nextLabel
				}
			};
			var mainStack = new StackLayout()
			{
				Padding = new Thickness(0.5, 5),
				Orientation = StackOrientation.Horizontal,
				Children =
				{
					image,
					midWholeStack,
					nextPage
				}
			};

			//instantiate each of our views
			View = mainStack;
		}

	}

}
