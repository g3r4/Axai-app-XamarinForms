using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;


namespace Axai
{	
	public partial class ContactForm
	{	
		private Dictionary<string, string> formValues = new Dictionary<string, string>();
		private string EmptyFields; 

		public ContactForm ()
		{
			InitializeComponent ();
		}
		public void OnSubmit(object sender, EventArgs e)
		{
			if (ValidateForm ()) {
				var result = this.POST ();
				if (result.IsSuccessStatusCode) {
					this.DisplayAlert ("Thank you", "We will get in touch with you very soon", "OK", null);	
				} else {
					this.DisplayAlert ("Remote server error", "There was a problem with our server, please try again later", "OK", null);	
				}
			}

		}

		public bool ValidateForm()
		{
			formValues.Clear ();
			this.EmptyFields = "";

			formValues.Add ("Name", entryName.Text);
			formValues.Add ("Email", entryEmail.Text);
			formValues.Add ("Phone", entryPhone.Text);
			formValues.Add ("Company", entryCompany.Text);
			formValues.Add ("Project Description", entryProjectDescription.Text);

			if (formValues["Name"] != null && formValues["Email"] != null && formValues["Project Description"] != null) {
				if (IsValidEmail (formValues ["Email"])) {
					labelEmail.TextColor = Color.Black;
					return true;
				}else {
					this.DisplayAlert ("Invalid E-mail Address", "Please, enter a valid e-mail address", "OK", null);
					labelEmail.TextColor = Color.Red;
					return false;
				}
			} else {
				foreach ( var formValue in formValues){
					if (formValue.Key!="Phone" && formValue.Key!="Company" && formValue.Value==null){
						EmptyFields+= "[" + formValue.Key + "] ";
					}
				}
				this.DisplayAlert ("Required fields are emtpy", EmptyFields, "OK", null);
				return false;
			}
		}

		private bool IsValidEmail(string emailaddress)
		{
			return Regex.IsMatch(emailaddress, 
								@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
								RegexOptions.IgnoreCase);
		}

		public HttpResponseMessage POST()
		{
			using (var client = new HttpClient ()) {
				using (var multipartFormDataContent = new MultipartFormDataContent ()) {
					var values = new[] {
						new KeyValuePair<string, string> ("submitted[name]", entryName.Text),
						new KeyValuePair<string, string> ("submitted[e_mail]", entryEmail.Text),
						new KeyValuePair<string, string> ("submitted[phone]", entryPhone.Text),
						new KeyValuePair<string, string> ("submitted[company]",  entryCompany.Text),
						new KeyValuePair<string, string> ("submitted[project_description]", entryProjectDescription.Text),
						new KeyValuePair<string, string> ("details[page_num]", "1"),
						new KeyValuePair<string, string> ("details[page_count]", "1"),
						new KeyValuePair<string, string> ("details[finished]", "0"),
						new KeyValuePair<string, string> ("form_build_id", "form-kyL43mrTY9n81cW2Z8h0FVf5D0wUipQ88zpXLulXm9Q"),
						new KeyValuePair<string, string> ("form_id", "webform_client_form_28"),
						new KeyValuePair<string, string> ("op", "Submit"),
						//other values
					};

					foreach (var keyValuePair in values) {
						multipartFormDataContent.Add (new StringContent (keyValuePair.Value), 
							String.Format ("\"{0}\"", keyValuePair.Key));
					}

					var requestUri = "http://www.axai.com.mx/en/contact";
					var result = client.PostAsync (requestUri, multipartFormDataContent).Result;
					System.Diagnostics.Debug.WriteLine (result);
					return result;
				}
			}
		}
	}
}

