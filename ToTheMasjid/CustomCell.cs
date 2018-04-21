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

			var nextPrayerLabel = new Label();
			//birthdayLabel.SetBinding(Label.TextProperty,
			//new Binding("AsrTime", BindingMode.OneWay,
			//null, null, "Born {0:d}"));
			nextPrayerLabel.Text = "Next: Maghreb. 15 minutes more";
			var image = new Image()
			{
				Source = "Pray32.png"
			};
			//boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");


			var stack = new StackLayout()
			{
				Padding = new Thickness(0, 5),
				Orientation = StackOrientation.Horizontal,
				Children =
			    {
					image,
				new StackLayout
				{
				    VerticalOptions = LayoutOptions.Center,
				    Spacing = 0,
				    Children =
				    {
					mosqueNameLabel,
					nextPrayerLabel
				    }
				}
			    }
			};

			//instantiate each of our views
			View = stack;
		}

	}

}
