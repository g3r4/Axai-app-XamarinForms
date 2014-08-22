using System;
using System.Collections.Generic;
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

				mbmbersViewModelObject = await new MembersViewModel().StartAsync(); 

				this.BindingContext = mbmbersViewModelObject; 

				this.IsBusy = false;

				//await this.DisplayAlert ("JSON", MembersList[0].SsName, "OK", null);
			}	
		}

		public void OnItemSelected(object sender, ItemTappedEventArgs args)
		{

			var member = args.Item as Member;
			if (member == null)
				return;


			//this.DisplayAlert ("Item selected", list.SelectedItem.ToString(), "OK", null);

			var memberDetails = new MemberDetails (member);

			Navigation.PushAsync( memberDetails);
			//Reset the selected item
			list.SelectedItem = null;
		}
	}
}



