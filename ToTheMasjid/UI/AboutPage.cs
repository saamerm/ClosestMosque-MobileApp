using Xamarin.Forms;

namespace ToTheMasjid
{
	public class AboutPage : ContentPage
	{
		public AboutPage()
		{
			Title = "About Page";

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
				Text = "About Page"
			};
			layout1.Children.Add(label2);
			var mainLayout = new StackLayout();
			mainLayout.Children.Add(layout1);
			Content = new ScrollView
			{
				Content = mainLayout
			};
		}
	}
}