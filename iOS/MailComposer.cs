using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Axai.iOS;
using Xamarin.Forms;
using System.Diagnostics;
using MonoTouch.MessageUI;

[assembly: Dependency(typeof(MailComposer))]

namespace Axai.iOS
{
	public class MailComposer : IeMailer
	{
	
		public bool  composeEmail(string emailadress){
		
			NSUrl url = new NSUrl(string.Format(@"mailto:{0}", emailadress));
			return UIApplication.SharedApplication.OpenUrl(url);

		}

	}
}