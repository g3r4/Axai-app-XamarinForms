using System.Linq;
using Xamarin.Forms;
using Axai.Android;
using Uri = Android.Net.Uri;
using Android.Content;

[assembly: Dependency(typeof(MailComposer))]

namespace Axai.Android
{
	public class MailComposer : IeMailer
	{
		public bool composeEmail(string emailadress){

			var context = Forms.Context;
			if (context == null)
				return false;

			var intent = new Intent (Intent.ActionSend);

			intent.PutExtra (Intent.ExtraEmail, 
				new string[]{emailadress} );
				
			intent.PutExtra (Intent.ExtraSubject, "Hello Axai");

			intent.SetType ("message/rfc822");


			if (IsIntentAvailable(context, intent)) {
				context.StartActivity(intent);
				return true;
			}

			return false;

		}

		/// <summary>
		/// Checks if an intent can be handled.
		/// </summary>
		public static bool IsIntentAvailable(Context context, Intent intent)
		{
			var packageManager = context.PackageManager;

			var list = packageManager.QueryIntentServices(intent, 0)
				.Union(packageManager.QueryIntentActivities(intent, 0));
			if (list.Any())
				return true;

			return false;

		}
	}
}

