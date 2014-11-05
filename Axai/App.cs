﻿//
//  App.cs
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