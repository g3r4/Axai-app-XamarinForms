using System;
using Xamarin.Forms;
namespace Axai
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var tabbedAxai = new TabbedAxai ();
			NavigationPage nav = new NavigationPage (tabbedAxai) { BarBackgroundColor = Color.FromHex("#428BCA"), BarTextColor = Color.White };
			return nav;
		}
	}
}