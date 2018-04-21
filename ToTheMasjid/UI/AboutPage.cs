using Xamarin.Forms;

namespace ToTheMasjid
{
	public class AboutPage : ContentPage
	{
		public AboutPage()
		{
			Title = "About";
			//var toolbarItem = new ToolbarItem
			//{
			//	Icon = "Logout.png"
			//};
			//toolbarItem.Clicked += OnLogoutButtonClicked;
			//ToolbarItems.Add(toolbarItem);
			BackgroundColor = Color.FromRgb(136, 189, 86);

			var mainLayout = new StackLayout();

			var layout1 = new StackLayout()
			{
				BackgroundColor = Color.FromHex("99CE78"),
				Opacity = 0.75,
				Padding = new Thickness(0, 40, 0, 40),
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var logo = new Image()
			{
				Source = "Pray64.png",
				HeightRequest = 64,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			layout1.Children.Add(logo);

			var layout2 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Spacing = 10,
				Padding = new Thickness(16, 40, 16, 40),
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var label1 = new Label()
			{
				FontSize = 22
			};
			var s1 = new FormattedString();
			s1.Spans.Add(new Span { Text = "To The Masjid", FontAttributes = FontAttributes.Bold, FontSize = 24 });
			s1.Spans.Add(new Span { Text = " " });
			s1.Spans.Add(new Span { Text = "1.0", ForegroundColor = Color.Gray });

			label1.FormattedText = s1;

			var label2 = new Label();
			var s2 = new FormattedString();
			s2.Spans.Add(new Span
			{
				Text = "This app serves the as a tool to find the nearest mosque and the next prayer time there for ",
			});
			s2.Spans.Add(new Span
			{
				Text = "Muslims",
				FontAttributes = FontAttributes.Bold
			});
			s2.Spans.Add(new Span { Text = " in Denver" });
			label2.FormattedText = s2;

			var label3 = new Label();
			var s3 = new FormattedString();
			s3.Spans.Add(new Span
			{
				Text = "Stay tuned, because more feaures like ",
			});
			s3.Spans.Add(new Span
			{
				Text = "Push Notifications",
				FontAttributes = FontAttributes.Bold
			});
			s3.Spans.Add(new Span
			{
				Text = " is on its way!"
			});
			label3.FormattedText = s3;

			var debugTapGestureRecognizer = new TapGestureRecognizer();
			debugTapGestureRecognizer.Tapped += (s, e) =>
			{

				DisplayAlert("Debug Mode", "Good job", "OK");
			};
			//tapGestureRecognizer3.NumberOfTapsRequired = 5;
			label3.GestureRecognizers.Add(debugTapGestureRecognizer);

			layout2.Children.Add(label1);
			layout2.Children.Add(label2);
			layout2.Children.Add(label3);

			mainLayout.Children.Add(layout1);
			mainLayout.Children.Add(layout2);
			Content = new ScrollView
			{
				Content = mainLayout
			};
		}
	}
}