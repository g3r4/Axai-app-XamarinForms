using System;
using Xamarin.Forms;

namespace Axai
{	
	public partial class ProjectDetails
	{	
		protected PortfolioProject currentProject;

		public ProjectDetails (PortfolioProject project)
		{
			InitializeComponent ();
			this.currentProject = project;
			this.BindingContext = this.currentProject;
		}

		public void OnButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync (new ContentPage () {
				Content = new WebView (){ Source = currentProject.SsFieldSiteUrl },
				Title = currentProject.SsTitle
			});
		}
	}
}

