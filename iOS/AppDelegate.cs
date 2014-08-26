using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;

namespace Axai.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{

			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
				{
					TextColor = UIColor.White
				});
						
			UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes()
				{

					TextColor = UIColor.White
				}, UIControlState.Normal);
						
			Forms.Init ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			window.RootViewController = App.GetMainPage ().CreateViewController ();
			// Change the tabs colors from blue(default) to orange
			window.RootViewController.View.TintColor = UIColor.Orange;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

