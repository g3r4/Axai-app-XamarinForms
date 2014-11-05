//
//  ExtendedTabbedPage.cs
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
using System.ComponentModel;

namespace Axai
{	
	public delegate void CurrentPageChangingEventHandler();
	public delegate void CurrentPageChangedEventHandler();

	public class ExtendedTabbedPage : TabbedPage
	{
		public event CurrentPageChangingEventHandler CurrentPageChanging;
		public new event CurrentPageChangedEventHandler CurrentPageChanged;

		public ExtendedTabbedPage()
		{
			this.PropertyChanging += this.OnPropertyChanging;
			this.PropertyChanged += this.OnPropertyChanged;
		}

		private void OnPropertyChanging(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName == "CurrentPage")
			{
				this.RaiseCurrentPageChanging();
			}
		}

		private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "CurrentPage")
			{
				this.RaiseCurrentPageChanged();
			}
		}

		private void RaiseCurrentPageChanging()
		{
			var handler = this.CurrentPageChanging;
			if (handler != null)
			{
				handler();
			}
		}

		private void RaiseCurrentPageChanged()
		{
			var handler = this.CurrentPageChanged;
			if (handler != null)
			{
				handler();
			}
		}
		protected override void OnCurrentPageChanged()
		{
			this.Title = this.CurrentPage.Title;
		}
	}
}

