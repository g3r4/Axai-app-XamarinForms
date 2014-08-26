using System;
using System.Collections.Generic;
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

			//this.DisplayAlert ("Item selected", list.SelectedItem.ToString(), "OK", null);

			//Navigation.PushAsync(new ContentPage(){Content= new WebView(){Source= ((Button)sender).Text }, Title=currentMember.SsFieldFullName } );
		}
	}
}

