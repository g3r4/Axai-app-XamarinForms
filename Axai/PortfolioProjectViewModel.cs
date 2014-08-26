using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Axai.Helpers;

namespace Axai
{
	public class PortfolioProjectViewModel : AbstractViewModel
	{
		public ObservableCollection<PortfolioProject> PortfolioProjects { get; set; }

		private const string projectsIndexJsonURI = "http://canek.axai.mx:8983/solr/collection1/select?q=*%3A*&fq=ss_type%3A+%22project%22&fq=ss_search_api_language%3A+%22en%22&rows=100&wt=json";
		private string json;

		async public Task<PortfolioProjectViewModel> StartAsync()
		{
			PortfolioProjects = new ObservableCollection<PortfolioProject>();

			this.json = await GetJsonFromDrupalAsync (projectsIndexJsonURI);		

			JObject jObj = JObject.Parse(json);

			// Iterate through all the Serialized Objects in the json

			for (int i = 0; i < Convert.ToInt32 (jObj ["response"] ["numFound"].ToString ()); i++) {

				string stringHolder;
				int stringIndex;

				PortfolioProject PortfolioProjectHolder = new PortfolioProject ();

				// Since some of the values expected from the json may no exist for all projects, check everything before, and assign
				// null to the PortfolioProject Object instance element in case of not finding that index in the json.

				PortfolioProjectHolder.Id = IndexKeyValue (jObj, "id", i);
				PortfolioProjectHolder.IndexId = IndexKeyValue (jObj, "index_id", i);
				PortfolioProjectHolder.ItemId = IndexKeyValue (jObj, "item_id", i);
				PortfolioProjectHolder.SsNid = IndexKeyValue (jObj, "ss_nid", i);
				PortfolioProjectHolder.SsType = IndexKeyValue (jObj, "ss_type", i);
				PortfolioProjectHolder.SsTitle = IndexKeyValue (jObj, "ss_title", i);
				PortfolioProjectHolder.SsUrl = IndexKeyValue (jObj, "ss_url", i);
				PortfolioProjectHolder.SsFieldProjectInfo = IndexKeyValue (jObj, "ss_field_project_info", i);
				PortfolioProjectHolder.SsBodyValue = IndexKeyValue (jObj, "ss_body:value", i);
				PortfolioProjectHolder.SsFieldSiteUrl = IndexKeyValue (jObj, "ss_field_site_s_url_:url", i);

				// Request a smaller version of the picture since the original one is very large (panopoly provides a quarter sized image)

				stringHolder = IndexKeyValue (jObj, "ss_field_featured_image:file:url", i);
				if (stringHolder != null) {
					stringIndex = stringHolder.IndexOf ("files/");
					PortfolioProjectHolder.SsFieldFeaturedImageUrl = stringHolder.Insert (stringIndex + "files/".Length, "styles/panopoly_image_quarter/public/");
				} else {
					PortfolioProjectHolder.SsFieldFeaturedImageUrl = null;
				}

				PortfolioProjects.Add (PortfolioProjectHolder);
			}

			return this;
		}
	}
}

