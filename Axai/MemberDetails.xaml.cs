//
//  MemberDetails.xaml.cs
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
using System;
using Xamarin.Forms;

namespace Axai
{	
	public partial class MemberDetails 
	{	
		protected Member currentMember;

		public MemberDetails (Member member)
		{
			InitializeComponent ();
			this.currentMember = member;
			this.BindingContext = this.currentMember;

		}

		protected override void OnAppearing(){

			//Since we can have members without some social networks, we have to hide the respective buttons and icons for them

			if (currentMember.SsFieldTwitUrl == null) {
				twitterButton.IsVisible = false;
				twitterIcon.IsVisible = false;
				twitterStack.IsVisible = false;
			}
			if (currentMember.SsFieldDrupalUrl == null) {
				drupalButton.IsVisible = false;
				drupalIcon.IsVisible = false;
				drupalStack.IsVisible = false;
			}
			if (currentMember.SsFieldGitUrl == null) {
				githubButton.IsVisible = false;
				githubIcon.IsVisible = false;
				githubStack.IsVisible = false;
			}
			if (currentMember.SsMail == null) {
				mailButton.IsVisible = false;
				mailIcon.IsVisible = false;
				mailStack.IsVisible = false;
			}
			if (currentMember.SsFieldFace == null) {
				facebookButton.IsVisible = false;
				facebookIcon.IsVisible = false;
				facebookStack.IsVisible = false;
			}
			if (currentMember.SsFieldFlickrUrl == null) {
				flickrButton.IsVisible = false;
				flickrIcon.IsVisible = false;
				flickrStack.IsVisible = false;
			}
		}
	
		public void OnButtonClicked(object sender, EventArgs e)
		{
			switch (((Button)sender).Text ) {
			case "Twitter":
				Navigation.PushAsync (new ContentPage () {
					Content = new WebView (){ Source = currentMember.SsFieldTwitUrl },
					Title = ((Button)sender).Text
				});
				break;
			case "Drupal":
				Navigation.PushAsync (new ContentPage () {
					Content = new WebView (){ Source = currentMember.SsFieldDrupalUrl },
					Title = ((Button)sender).Text
				});
				break;
			case "Github":
				Navigation.PushAsync (new ContentPage () {
					Content = new WebView (){ Source = currentMember.SsFieldGitUrl },
					Title = ((Button)sender).Text
				});
				break;
			case "Facebook":
				Navigation.PushAsync (new ContentPage () {
					Content = new WebView (){ Source = currentMember.SsFieldFace },
					Title = ((Button)sender).Text
				});
				break;
			case "Flickr":
				Navigation.PushAsync (new ContentPage () {
					Content = new WebView (){ Source = currentMember.SsFieldFlickrUrl },
					Title = ((Button)sender).Text
				});
				break;
			case "e-Mail":
				this.DisplayAlert (currentMember.SsFieldFullName + " e-Mail is:", currentMember.SsMail , "OK");
				break;
			}
		
			//this.DisplayAlert ("Item selected", list.SelectedItem.ToString(), "OK", null);
		}

		async void OnMailButtonClicked(object sender, EventArgs e){
			if (await this.DisplayAlert(
				"Send e-mail",
				"Would you like to send an email to " + currentMember.SsMail + "?",
				"Yes",
				"No"))
			{
				var mailer = DependencyService.Get<IeMailer>();
				if (mailer != null)
				{
					mailer.composeEmail(currentMember.SsMail);
				}
			}
		}
	}
}

