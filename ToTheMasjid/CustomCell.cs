using System;
using Xamarin.Forms;

namespace ToTheMasjid
{
	public class CustomCell : ViewCell
	{
		public void CustomCell1()
		{
			//Practicing Grids
			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =
				{
				    new RowDefinition { Height = GridLength.Auto },
				    new RowDefinition { Height = GridLength.Auto },
				    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
				    //new RowDefinition { Height = new GridLength(4, GridUnitType.Absolute) }
				},
				ColumnDefinitions =
				{
				    new ColumnDefinition { Width = GridLength.Auto },
				    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				    //new ColumnDefinition { Width = new GridLength(4, GridUnitType.Absolute) }
				}
			};

			//grid.Children.Add(new Label
			//{
			//	Text = "Grid",
			//	FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
			//	HorizontalOptions = LayoutOptions.Center
			//}, 0, 3, 0, 1);
			//left, right, top, bottom
			//or just left, top

			grid.Children.Add(new Label
			{
				Text = " ",
				TextColor = Color.White,
				BackgroundColor = Color.Blue
			}, 0, 1);

			grid.Children.Add(new BoxView
			{
				Color = Color.Silver,
				//HeightRequest = 0
			}, 1, 1);

			grid.Children.Add(new BoxView
			{
				Color = Color.Teal
			}, 0, 2);

			grid.Children.Add(new Label
			{
				Text = "Leftover space",
				TextColor = Color.Purple,
				BackgroundColor = Color.Aqua,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
			}, 1, 2);
			//grid.Children.Add(new Label
			//{
			//	Text = "Fixed 100x100",
			//	TextColor = Color.Aqua,
			//	BackgroundColor = Color.Red,
			//	HorizontalTextAlignment = TextAlignment.Center,
			//	VerticalTextAlignment = TextAlignment.Center
			//}, 2, 3);
			View = grid;
		}

		//Old CustomCell
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
