﻿using System;
using Xamarin.Forms;

namespace Axai
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new TabbedAxai ();

		}
	}
}
