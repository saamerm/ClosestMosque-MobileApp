using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms; 
namespace ToTheMasjid
{
	public class MosquesPage : ContentPage
	{
		//ObservableCollection<object> mosqueDisplay. = new ObservableCollection<object>();
		Mosques mosqueDisplay = new Mosques();
		ListView listViewJson = new ListView();

		public MosquesPage()
		{
			Title = "Mosques";

			// Use this to Add a get current location Target or GPS arrow button 
			//var toolbarItem = new ToolbarItem
			//{
			//	Icon = "Logout.png"
			//};
			//toolbarItem.Clicked += OnLogoutButtonClicked;
			//ToolbarItems.Add(toolbarItem);

			//BackgroundColor = Colors.AlmostSilver;//Colors.Base1;

			GetJSON();

			ViewModel = new PullToRefresh();

			this.BindingContext = ViewModel;

			listViewJson = new ListView
			{

				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				IsPullToRefreshEnabled = true,
				RefreshCommand = LoadTestCommand,

			};
			listViewJson.SetBinding(ListView.IsRefreshingProperty, "IsBusy", BindingMode.OneWay);
		}

		public async void GetJSON()
		{
			try
			{
				var client = new System.Net.Http.HttpClient();
				var response = await client.GetAsync("https://raw.githubusercontent.com/saamerm/ClosestMosque-MobileApp/master/NoSQLStorage/MosquesList.json");
				string json = await response.Content.ReadAsStringAsync();
				listViewJson.HasUnevenRows = true;
				listViewJson.ItemSelected += listViewJson_ItemSelected;

				if (json != "")
				{
					mosqueDisplay = JsonConvert.DeserializeObject<Mosques>(json);
				}
				DataTemplate template = new DataTemplate(typeof(CustomCell));
				listViewJson.ItemTemplate = template;
				listViewJson.IsPullToRefreshEnabled = true;

				listViewJson.ItemsSource = mosqueDisplay.value;

				// Show only Closest 10
				//listViewJson.ItemAppearing += (object sender, ItemVisibilityEventArgs e) => {

				//	var viewCellDetails = e.Item as object;
				//	int viewCellIndex = mosqueCollection.IndexOf(viewCellDetails);

				//	if (mosqueCollection.Count > 10)
				//	{
				//		if (viewCellIndex == mosqueCollection.Count - 1)
				//		{
				//			var page = (mosqueCollection.Count / 10);
				//			//skip already shown, add new ones
				//			for (int i = page * 10; i < (page * 10) + 10; i++)
				//			{
				//				mosqueCollection.Add(mosqueDisplay.value.ElementAt(i));
				//			}
				//		}
				//	}
				//};
				listViewJson.IsPullToRefreshEnabled = true;
				Content = listViewJson;
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void listViewJson_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as Mosque;
			Navigation.PushAsync(new MosquesDetailPage(item));
		}

		private PullToRefresh ViewModel { get; set; }

		private Command loadTestCommand;

		public Command LoadTestCommand
		{
			get
			{
				return loadTestCommand ?? (loadTestCommand = new Command(ExecuteLoadTestCommand, () => {
					return !ViewModel.IsBusy;
				}));
			}

		}

		private async void ExecuteLoadTestCommand()
		{
			if (ViewModel.IsBusy) 
				return;
			ViewModel.IsBusy = true;
			LoadTestCommand.ChangeCanExecute();
			//DoStuff 
			listViewJson.ItemsSource = mosqueDisplay.value;
			ViewModel.IsBusy = false;
			LoadTestCommand.ChangeCanExecute();
			listViewJson.EndRefresh();
		}
	}
} 