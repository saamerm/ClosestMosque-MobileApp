using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;

using XLabs.Ioc; // Using for SimpleContainer
using XLabs.Platform.Services.Geolocation; // Using for Geolocation 
using XLabs.Platform.Device; // Using for Device

namespace ToTheMasjid.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			var container = new XLabs.Ioc.SimpleContainer(); // Create SimpleCOntainer
			container.Register<IDevice>(t => AppleDevice.CurrentDevice); // Register Device
			container.Register<IGeolocator, Geolocator>(); // Register Geolocator
			Resolver.SetResolver(container.GetResolver()); // Resolving the services

			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
