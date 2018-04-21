using Xamarin.Forms;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ToTheMasjid
{
	public class NotificationsPage : ContentPage
	{
		public void NotificationsPage1()
		{
			#region Constructor
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
			var mainLayout = new StackLayout();
			mainLayout.Children.Add(layout1);
			Content = new ScrollView
			{
				Content = mainLayout
			};
			#endregion
		}

		int count;
		bool tracking;
		Position savedPosition;
		public ObservableCollection<Position> Positions { get; } = new ObservableCollection<Position>();

		//TO BE USED
		Button ButtonCached = new Button() { Text = "Get Last Known Location" };
		Label LabelCached = new Label() { };
		ListView ListViewPositions = new ListView() { };

		Button ButtonGetGPS = new Button() { Text = "Get Current Location" };
		Label labelGPS = new Label() { };
		Button ButtonAddressForPosition = new Button() { Text = "Get Address for Position", IsEnabled = true };

		Label LabelAddress = new Label() { };
		Label labelGPSTrack = new Label() { };
		Button ButtonTrack = new Button() { };
		Label LabelCount = new Label() { };
		Stepper DesiredAccuracy = new Stepper() { };
		Switch TrackIncludeHeading = new Switch() { };
		Stepper Timeout = new Stepper() { Value = 20 };
		Switch IncludeHeading = new Switch() { };
		public NotificationsPage()
		{
			ButtonCached.Clicked += ButtonCached_Clicked;
			ButtonGetGPS.Clicked += ButtonGetGPS_Clicked;
			ButtonAddressForPosition.Clicked += ButtonAddressForPosition_Clicked;
			ListViewPositions.ItemsSource = Positions;

			var stack = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
			stack.Children.Add(ButtonCached);
			stack.Children.Add(LabelCached);

			stack.Children.Add(ButtonGetGPS);
			stack.Children.Add(labelGPS);

			stack.Children.Add(ButtonAddressForPosition);
			stack.Children.Add(LabelAddress);

			Content = new ScrollView() { Content = stack };

		}

		private async void ButtonCached_Clicked(object sender, EventArgs e)
		{
			try
			{
				var hasPermission = await Utils.CheckPermissions(Permission.Location);
				if (!hasPermission)
					return;

				ButtonCached.IsEnabled = false;

				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = DesiredAccuracy.Value;
				LabelCached.Text = "Getting gps...";

				var position = await locator.GetLastKnownLocationAsync();

				if (position == null)
				{
					LabelCached.Text = "null cached location :(";
					return;
				}

				savedPosition = position;
				ButtonAddressForPosition.IsEnabled = true;
				LabelCached.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
					position.Timestamp, position.Latitude, position.Longitude,
					position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

			}
			catch (Exception ex)
			{
				await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured for analysis! Thanks.", "OK");
			}
			finally
			{
				ButtonCached.IsEnabled = true;
			}
		}

		private async void ButtonGetGPS_Clicked(object sender, EventArgs e)
		{
			try
			{
				var hasPermission = await Utils.CheckPermissions(Permission.Location);
				if (!hasPermission)
					return;

				ButtonGetGPS.IsEnabled = false;

				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = DesiredAccuracy.Value;
				labelGPS.Text = "Getting gps...";

				var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(Timeout.Value), null, IncludeHeading.IsToggled);

				if (position == null)
				{
					labelGPS.Text = "null gps :(";
					return;
				}
				savedPosition = position;
				ButtonAddressForPosition.IsEnabled = true;
				labelGPS.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
					position.Timestamp, position.Latitude, position.Longitude,
					position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

			}
			catch (Exception ex)
			{
				await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured for analysis! Thanks.", "OK");
			}
			finally
			{
				ButtonGetGPS.IsEnabled = true;
			}
		}

		private async void ButtonAddressForPosition_Clicked(object sender, EventArgs e)
		{
			try
			{
				if (savedPosition == null)
					return;

				var hasPermission = await Utils.CheckPermissions(Permission.Location);
				if (!hasPermission)
					return;

				ButtonAddressForPosition.IsEnabled = false;

				var locator = CrossGeolocator.Current;

				var address = await locator.GetAddressesForPositionAsync(savedPosition, "RJHqIE53Onrqons5CNOx~FrDr3XhjDTyEXEjng-CRoA~Aj69MhNManYUKxo6QcwZ0wmXBtyva0zwuHB04rFYAPf7qqGJ5cHb03RCDw1jIW8l");
				if (address == null || address.Count() == 0)
				{
					LabelAddress.Text = "Unable to find address";
				}

				var a = address.FirstOrDefault();
				LabelAddress.Text = $"Address: Thoroughfare = {a.Thoroughfare}\nLocality = {a.Locality}\nCountryCode = {a.CountryCode}\nCountryName = {a.CountryName}\nPostalCode = {a.PostalCode}\nSubLocality = {a.SubLocality}\nSubThoroughfare = {a.SubThoroughfare}";

			}
			catch (Exception ex)
			{
				await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured for analysis! Thanks.", "OK");
			}
			finally
			{
				ButtonAddressForPosition.IsEnabled = true;
			}
		}

		//private async void ButtonTrack_Clicked(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		var hasPermission = await Utils.CheckPermissions(Permission.Location);
		//		if (!hasPermission)
		//			return;

		//		if (tracking)
		//		{
		//			CrossGeolocator.Current.PositionChanged -= CrossGeolocator_Current_PositionChanged;
		//			CrossGeolocator.Current.PositionError -= CrossGeolocator_Current_PositionError;
		//		}
		//		else
		//		{
		//			CrossGeolocator.Current.PositionChanged += CrossGeolocator_Current_PositionChanged;
		//			CrossGeolocator.Current.PositionError += CrossGeolocator_Current_PositionError;
		//		}

		//		if (CrossGeolocator.Current.IsListening)
		//		{
		//			await CrossGeolocator.Current.StopListeningAsync();
		//			labelGPSTrack.Text = "Stopped tracking";
		//			ButtonTrack.Text = "Start Tracking";
		//			tracking = false;
		//			count = 0;
		//		}
		//		else
		//		{
		//			Positions.Clear();
		//			if (await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(TrackTimeout.Value), TrackDistance.Value,
		//				TrackIncludeHeading.IsToggled, new ListenerSettings
		//				{
		//					ActivityType = (ActivityType)ActivityTypePicker.SelectedIndex,
		//					AllowBackgroundUpdates = AllowBackgroundUpdates.IsToggled,
		//					DeferLocationUpdates = DeferUpdates.IsToggled,
		//					DeferralDistanceMeters = DeferalDistance.Value,
		//					DeferralTime = TimeSpan.FromSeconds(DeferalTIme.Value),
		//					ListenForSignificantChanges = ListenForSig.IsToggled,
		//					PauseLocationUpdatesAutomatically = PauseLocation.IsToggled
		//				}))
		//			{
		//				labelGPSTrack.Text = "Started tracking";
		//				ButtonTrack.Text = "Stop Tracking";
		//				tracking = true;
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured for analysis! Thanks.", "OK");
		//	}
		//}




		//void CrossGeolocator_Current_PositionError(object sender, PositionErrorEventArgs e)
		//{

		//	labelGPSTrack.Text = "Location error: " + e.Error.ToString();
		//}

		//void CrossGeolocator_Current_PositionChanged(object sender, PositionEventArgs e)
		//{

		//	Device.BeginInvokeOnMainThread(() =>
		//	{
		//		var position = e.Position;
		//		Positions.Add(position);
		//		count++;
		//		LabelCount.Text = $"{count} updates";
		//		labelGPSTrack.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
		//			position.Timestamp, position.Latitude, position.Longitude,
		//			position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

		//	});
		//}
	}
}

