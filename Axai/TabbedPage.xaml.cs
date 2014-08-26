using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

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
			this.Children.Add(new ContentPage () {
				Content = new WebView (){ Source = "http://www.axai.com.mx/blog-all" },
				Title = "Blog", Icon="IconBlog.png"
			});

			// Add Children 3 of 4: Portfolio Page
			this.Children.Add(new PortfolioPage ());

			// Add Childern 4 of 4: Contact Form
			this.Children.Add (new ContactForm ());


			currentPage = this.CurrentPage;
			this.BindingContext = currentPage; 

			this.CurrentPageChanged += OnCurrentPageChanged;
		}
		private void OnCurrentPageChanged()
		{
			this.Title = this.CurrentPage.Title;
		}
	}
}

