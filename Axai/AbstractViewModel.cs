using System;
using System.Net; 
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace Axai
{
	public abstract class AbstractViewModel
	{
		public async Task<string> GetJsonFromDrupalAsync (string uri) {
			var client = new System.Net.Http.HttpClient ();
			client.BaseAddress = new Uri(uri);
			try {
				var response = await client.GetAsync("");
				if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
					return null;		
					}
				return response.Content.ReadAsStringAsync().Result;
			} catch (WebException e){
				return null;
			}
		}

		// This method checks if an indexKey exists in a JObject, if it does, returns the value of the Index key, if it doesn't
		// returns a null string

		public string IndexKeyValue(JObject jObj, string indexKey, int i){

			string valueString;

			try{
				if (indexKey == "tm_field_bio:value")
				{
					valueString = jObj["response"] ["docs"] [i] [indexKey][0].ToString() ;
				}
				else
				{
					valueString = jObj["response"] ["docs"] [i] [indexKey].ToString() ;
				}
			} catch (NullReferenceException){
				valueString = null;
			} 
			return valueString;


		}

	}
}

