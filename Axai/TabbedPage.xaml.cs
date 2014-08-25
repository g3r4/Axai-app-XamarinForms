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

			this.Children.Add(new MembersPage ());
			this.Children.Add(new ContentPage () {
				Content = new WebView (){ Source = "http://www.axai.com.mx/blog-all" },
				Title = "Blog", Icon="xaml.png"
			});
			currentPage = this.CurrentPage;
			this.BindingContext = currentPage; 

			this.CurrentPageChanged += OnCurrentPageChanged;
		}
		private void OnCurrentPageChanged()
		{
			//this.DisplayAlert("hola",this.CurrentPage.Title,"OK",null);
			this.Title = this.CurrentPage.Title;
		}
	}
}

