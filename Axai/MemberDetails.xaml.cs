using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Axai
{	
	public partial class MemberDetails 
	{	
		private Member currentMember;

		public MemberDetails (Member member)
		{
			InitializeComponent ();
			this.currentMember = member;
			this.BindingContext = this.currentMember;

		}
		public void OnTwitterButtonClicked(object sender, EventArgs e)
		{
		
			//this.DisplayAlert ("Item selected", list.SelectedItem.ToString(), "OK", null);

			Navigation.PushAsync(new ContentPage(){Content= new WebView(){Source= currentMember.SsFieldTwitUrl }, Title=currentMember.SsName } );
		}
	}
}

