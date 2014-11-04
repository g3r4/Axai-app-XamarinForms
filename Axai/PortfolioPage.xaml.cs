
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

				do{
					projectsViewModelObject = await new PortfolioProjectViewModel().StartAsync();
					if (projectsViewModelObject == null){
						await this.DisplayAlert ("Connection Error", "The Server could not be reached. Please check that you have an active internet connection and try again.", "Try Again");
					}
				}while (projectsViewModelObject == null);


				this.BindingContext = projectsViewModelObject; 

				this.IsBusy = false;

			}	
		}

		public void OnItemSelected(object sender, ItemTappedEventArgs args)
		{

			var project = args.Item as PortfolioProject;
			if (project == null)
				return;
				
			var projectDetails = new ProjectDetails (project);

			Navigation.PushAsync( projectDetails);
			//Reset the selected item
			projectslist.SelectedItem = null;
		}
	}
}



