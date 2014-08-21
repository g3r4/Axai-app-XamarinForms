using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Axai
{	
	public partial class TabbedAxai
	{	
		public TabbedAxai ()
		{
			//this.IsBusy=true;

			InitializeComponent ();
		}
		protected override async void OnAppearing(){

			this.IsBusy=true;

			MembersViewModel mbmbersViewModelObject = await new MembersViewModel().StartAsync(); 

			this.BindingContext = mbmbersViewModelObject; 

			this.IsBusy = false;


			//await this.DisplayAlert ("JSON", MembersList[0].SsName, "OK", null);
		}

		public void OnItemSelected(object sender, ItemTappedEventArgs args)
		{
			var member = args.Item as Member;
			if (member == null)
				return;

			this.DisplayAlert ("Item selected", list.SelectedItem.ToString(), "OK", null);

			Navigation.PushAsync(new Page());
			// Reset the selected item
			list.SelectedItem = null;
		}
	}
}

