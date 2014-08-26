using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Axai
{	
	public partial class PortfolioPage
	{	
		private PortfolioProjectViewModel projectsViewModelObject = null;

		public PortfolioPage ()
		{
			InitializeComponent ();
		}
		protected override async void OnAppearing(){

			// Just load the json one time, once it is populated, the object can be used across the application, no need to re-request it everytime OnAppearing gets called
			if (projectsViewModelObject == null){

				this.IsBusy=true;

				projectsViewModelObject = await new PortfolioProjectViewModel().StartAsync(); 

				this.BindingContext = projectsViewModelObject; 

				this.IsBusy = false;

				//await this.DisplayAlert ("JSON", MembersList[0].SsName, "OK", null);
			}	
		}

		public void OnItemSelected(object sender, ItemTappedEventArgs args)
		{

			var project = args.Item as PortfolioProject;
			if (project == null)
				return;


			//this.DisplayAlert ("Item selected", project.SsFieldFeaturedImageUrl.ToString() , "OK", null);

			var projectDetails = new ProjectDetails (project);

			Navigation.PushAsync( projectDetails);
			//Reset the selected item
			projectslist.SelectedItem = null;
		}
	}
}



