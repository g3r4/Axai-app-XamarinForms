//
//  MailComposer.cs
//
//  Author:
//       Gerardo M. <gerardo@axai.com.mx>
//
//  Copyright (c) 2014 2014
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
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

