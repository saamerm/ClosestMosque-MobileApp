using System;
using Newtonsoft.Json;
using Xamarin.Forms;
namespace ToTheMasjid
{
	public class MosquesDetailPage : ContentPage
	{
		private Mosque v;
		Label labl = new Label
		{
			Text = "MosqueDeets",
			HorizontalOptions = LayoutOptions.Center,
			FontSize = 20,
			TextColor = Color.Purple,
			FontAttributes = FontAttributes.Bold
		};

		Label lblAddress = new Label { Text = "" };

		public MosquesDetailPage(Mosque mosqueDetail)
		{
			v = mosqueDetail;
			Display();
		}

		public void Display()
		{
			try
			{
				labl.Text = v.name;
				lblAddress.LineBreakMode = LineBreakMode.WordWrap;
				lblAddress.Text = v.Address;
			}
			catch (Exception e)
			{
				throw e;
			}

			var stack = new StackLayout
			{
				Spacing = 10,
				Padding = 20,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = { labl, lblAddress }
			};
			Content = stack;
		}
	}
}