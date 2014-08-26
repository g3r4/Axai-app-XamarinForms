using System;
using System.Net; 
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;


namespace Axai
{
	public abstract class AbstractViewModel
	{
		public async Task<string> GetJsonFromDrupalAsync (string uri) {
			var client = new System.Net.Http.HttpClient ();
			client.BaseAddress = new Uri(uri);
			var response = await client.GetAsync("");
			return response.Content.ReadAsStringAsync().Result;
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
			} catch (System.NullReferenceException){
				valueString = null;
			} 
			return valueString;


		}

	}
}

