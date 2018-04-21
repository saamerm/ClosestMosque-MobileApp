using System;
using Newtonsoft.Json;
using Xamarin.Forms;
namespace ToTheMasjid
{
	public class MosquesDetailPage : ContentPage
	{
		private Mosque v;

		public MosquesDetailPage(Mosque mosqueDetail)
		{
			Title = mosqueDetail.name;
			v = mosqueDetail;
			Display();
		}

		public void Display()
		{
			Label labl = new Label
			{
				Text = "MosqueDeets",
				HorizontalOptions = LayoutOptions.Center,
				FontSize = 20,
				TextColor = Color.Purple,
				FontAttributes = FontAttributes.Bold
			};

			Label lblAddress = new Label
			{
				Text = "",
				FontSize = 17,
				TextColor = Color.Black,
			};

			var prayerTimes = new Label()
			{
				FontSize = 14,
				TextColor = Color.Silver,
			};
			try
			{
				labl.Text = v.name;
				lblAddress.LineBreakMode = LineBreakMode.WordWrap;
				lblAddress.Text = v.Address + "\n" + v.PhoneNumber + "\n" + v.Website;
				prayerTimes.Text = "Prayer Times are as follows-" + "\n" 
					+ "Fajr : " + v.FajrTime + "\n"
					+ "Dhuhr : " + v.DhuhrTime + "\n"
					+ "Asr : " + v.AsrTime + "\n"
					+ "Maghreb : " + v.MaghrebTime + "\n"
					+ "Isha : " + v.IshaTime + "\n"
					+ "Jummah 1 : " + v.Jummah1Time + "\n"
					+ "Jummah 2 : " + v.Jummah2Time + "\n"
					+"";
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
				Children = { labl, lblAddress, prayerTimes }
			};
			Content = new ScrollView { Content = stack };
		}
	}
}