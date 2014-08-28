using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Axai
{
	public class FormPost
	{
		static public void GET(){
			CookieContainer cookies = new CookieContainer();
			HttpClientHandler handler = new HttpClientHandler();
			handler.CookieContainer = cookies;

			HttpClient client = new HttpClient(handler);
			HttpResponseMessage response = client.GetAsync("https://google.com").Result;

			Uri uri = new Uri("https://google.com");
			IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
			System.Diagnostics.Debug.WriteLine ("WTF");
			foreach (Cookie cookie in responseCookies)
				System.Diagnostics.Debug.WriteLine(cookie.Name + ": " + cookie.Value);

		}
//		public async Task<JsonObject> PostAsync(string uri, string data)
//		{
//			var httpClient = new HttpClient();
//			response = await httpClient.PostAsync(uri, new StringContent(data));
//
//			response.EnsureSuccessStatusCode();
//
//			string content = await response.Content.ReadAsStringAsync();
//			return await Task.Run(() =&gt; JsonObject.Parse(content));
//		}
		static async public Task POST()
		{
			using (var client = new HttpClient())
			{
				using (var multipartFormDataContent = new MultipartFormDataContent())
				{
					var values = new[]
					{
						new KeyValuePair<string, string>("submitted[name]", "C3PO citripio"),
						new KeyValuePair<string, string>("submitted[e_mail]", "c3p0@starwars.com"),
						new KeyValuePair<string, string>("submitted[phone]", "333-4567-678"),
						new KeyValuePair<string, string>("submitted[company]", "Millenium Falcon"),
						new KeyValuePair<string, string>("submitted[project_description]", "Death Star Enhancements"),
						new KeyValuePair<string, string>("details[page_num]", "1"),
						new KeyValuePair<string, string>("details[page_count]", "1"),
						new KeyValuePair<string, string>("details[finished]", "0"),
						new KeyValuePair<string, string>("form_build_id", "form-kyL43mrTY9n81cW2Z8h0FVf5D0wUipQ88zpXLulXm9Q"),
						new KeyValuePair<string, string>("form_id", "webform_client_form_28"),
						new KeyValuePair<string, string>("op", "Submit"),
						//other values
					};

					foreach (var keyValuePair in values)
					{
						multipartFormDataContent.Add(new StringContent(keyValuePair.Value), 
							String.Format("\"{0}\"", keyValuePair.Key));
					}
						
					var requestUri = "http://www.axai.com.mx/en/contact";
					var result = client.PostAsync(requestUri, multipartFormDataContent).Result;
					System.Diagnostics.Debug.WriteLine (result);
				}
			}
		}
	}
}

