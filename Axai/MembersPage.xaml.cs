
using Xamarin.Forms;

namespace Axai
{	
	public partial class MembersPage
	{	
		private MembersViewModel mbmbersViewModelObject = null;

		public MembersPage ()
		{
			InitializeComponent ();
		}
		protected override async void OnAppearing(){

			// Just load the json one time, once it is populated, the object can be used across the application, no need to re-request it everytime OnAppearing gets called
			if (mbmbersViewModelObject == null){

				this.IsBusy=true;

				do{
					mbmbersViewModelObject = await new MembersViewModel().StartAsync(); 
					if (mbmbersViewModelObject == null){
						await this.DisplayAlert ("Connection Error", "The Server could not be reached. Please check that you have an active internet connection and try again.", "Try Again");
					}
				}while (mbmbersViewModelObject == null);


				this.BindingContext = mbmbersViewModelObject; 

				this.IsBusy = false;

			}	
		}

		public void OnItemSelected(object sender, ItemTappedEventArgs args)
		{

			var member = args.Item as Member;
			if (member == null)
				return;
				
			var memberDetails = new MemberDetails (member);

			Navigation.PushAsync( memberDetails);
			//Reset the selected item
			list.SelectedItem = null;
		}
	}
}



