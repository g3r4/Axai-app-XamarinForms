//
//  TabbedPage.xaml.cs
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
	public partial class TabbedAxai : ExtendedTabbedPage
	{	
		Page currentPage;
		public TabbedAxai ()
		{

			InitializeComponent ();

			// Add Children 1 of 4: Members Page
			this.Children.Add(new MembersPage ());

			// Add Children 2 of 4: Blog Page
			this.Children.Add(new BlogPage ()) ;

			// Add Children 3 of 4: Portfolio Page
			this.Children.Add(new PortfolioPage ());

			// Add Childern 4 of 4: Contact Form
			this.Children.Add (new ContactForm ());


			currentPage = this.CurrentPage;
			this.BindingContext = currentPage; 

			this.CurrentPageChanged += OnCurrentPageChanged;
		}
	}
}

