//
//  AbstractViewModel.cs
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
				if (response.StatusCode == HttpStatusCode.NotFound) {
					return null;		
					}
				return response.Content.ReadAsStringAsync().Result;
			} catch (WebException){
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

