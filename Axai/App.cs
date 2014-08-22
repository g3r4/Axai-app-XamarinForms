﻿using System;
using Xamarin.Forms;
namespace Axai
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var tabbedAxai = new TabbedAxai ();
			NavigationPage nav = new NavigationPage (tabbedAxai) { Tint = Color.FromHex("#428BCA") };
			return nav;
		}
	}
}