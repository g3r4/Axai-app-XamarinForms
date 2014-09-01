using System;
using Xamarin.Forms;

namespace Axai
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var tabbedAxai = new TabbedAxai ();
			var nav = new NavigationPage (tabbedAxai) {BarBackgroundColor = Color.FromHex("428BCA")} ;
			return nav;

		}
	}
}
