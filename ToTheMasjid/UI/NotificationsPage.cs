using Xamarin.Forms;
using XLabs.Platform.Device;
using XLabs.Platform;
using XLabs.Ioc;
using XLabs.Platform.Services.Geolocation;
using System.Threading.Tasks;
using System;

namespace ToTheMasjid
{
	public class NotificationsPage : ContentPage
	{
		StackLayout mainLayout = new StackLayout();

		public NotificationsPage()
		{
			Title = "Notifications Page";

			// Use this to Add a get current location Target or GPS arrow button 
			//var toolbarItem = new ToolbarItem
			//{
			//	Icon = "Logout.png"
			//};
			//toolbarItem.Clicked += OnLogoutButtonClicked;
			//ToolbarItems.Add(toolbarItem);

			BackgroundColor = Color.FromRgb(136, 72, 190);

			var layout1 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Opacity = 0.75,
				Padding = new Thickness(10, 40, 10, 40),
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var label1 = new Label()
			{
				FontSize = 22
			};
			var s1 = new FormattedString();
			s1.Spans.Add(new Span { Text = "ToTheMasjid", FontAttributes = FontAttributes.Bold, FontSize = 24 });
			s1.Spans.Add(new Span { Text = " " });
			s1.Spans.Add(new Span { Text = "1.0", ForegroundColor = Color.Gray });

			label1.FormattedText = s1;
			layout1.Children.Add(label1);
			var label2 = new Label()
			{
				Text = "Notifications Page"
			};
			layout1.Children.Add(label2);

			//var oGeolocator = Resolver.Resolve<IGeolocator>(); // Resolve the Geolocator over the resolver
			var button = new Button()
			{
				Text = "Click"
			};
			button.Clicked += Button_Clicked;
			mainLayout.Children.Add(layout1);
			Content = new ScrollView
			{
				Content = mainLayout
			};
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			var x = GetPosition(20);
			var coordinates = new Label()
			{
				Text = x.Result.Latitude.ToString() + "Latitude"
			};
			mainLayout.Children.Add(coordinates);
		}

		public async Task<Position> GetPosition(int x)
		{
			var oGeolocator = Resolver.Resolve<IGeolocator>(); // Resolve the Geolocator over the resolver
			var y = await oGeolocator.GetPositionAsync(x);

			return y;
		}
	}
}