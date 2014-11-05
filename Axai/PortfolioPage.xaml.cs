//
//  PortfolioPage.xaml.cs
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



