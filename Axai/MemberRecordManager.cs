using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Axai
{
	public class MemberRecordManager : AbstractViewModel
	{
		// URI to get json from the Solr server containing all teammembers in English
		private const string membersIndexJsonURI = "http://canek.axai.mx:8983/solr/collection1/select?q=*%3A*&fq=ss_search_api_language%3A\"en\"&wt=json";
		private List<Member> MembersList = new List<Member>();

		public MemberRecordManager()
		{
		}

		public string MembersIndexJsonURIProperty 
		{
			get 
			{
				return membersIndexJsonURI;
			}
		}

		public List <Member> DeserializeJsonToMemberList (string json){
		
			JObject jObj = JObject.Parse(json);

			// Iterate through all the Serialized Objects in the json

			for (int i = 0; i < Convert.ToInt32(jObj ["response"] ["numFound"].ToString() ); i++) {

				Member MemberHolder = new Member();

				// Since some of the values expected from the json may no exist for all members, check everything before, and assign
				// null to the Member Object instance element in case of not finding that index in the json.

				MemberHolder.Id 	 = IndexKeyValue (jObj, "id", i);
				MemberHolder.IndexId = IndexKeyValue (jObj, "index_id", i);
				MemberHolder.ItemId = IndexKeyValue (jObj, "item_id", i);
				MemberHolder.SsFieldBioValue = IndexKeyValue (jObj, "ss_field_bio:value", i);
				MemberHolder.SsFieldDrupalUrl = IndexKeyValue (jObj, "ss_field_drupal_:url", i);
				MemberHolder.SsFieldGitUrl = IndexKeyValue(jObj, "ss_field_git:url", i);
				MemberHolder.SsFieldInterestingValue = IndexKeyValue(jObj, "ss_field_interesting:value", i);
				MemberHolder.SsFieldTwitUrl = IndexKeyValue(jObj, "ss_field_twit:url", i);
				MemberHolder.SsFieldUserPictureFileUrl = IndexKeyValue(jObj, "ss_field_user_picture:file:url", i);
				MemberHolder.SsMail = IndexKeyValue(jObj, "ss_mail", i);
				MemberHolder.SsName = IndexKeyValue(jObj, "ss_name", i);
				MemberHolder.SsSearchApiLanguage = IndexKeyValue(jObj, "ss_search_api_language", i);
				MemberHolder.SsUid = IndexKeyValue(jObj, "ss_uid", i);
				MemberHolder.SsUrl = IndexKeyValue(jObj, "ss_url", i);
				MemberHolder.Timestamp = IndexKeyValue(jObj, "timestamp", i);
				MemberHolder.SsFieldFace = IndexKeyValue(jObj, "ss_field_face", i); 
				MemberHolder.SsFieldFlickrUrl = IndexKeyValue(jObj, "ss_field_flickr_:url", i);  
				MemberHolder.SsFieldFullName = IndexKeyValue(jObj, "ss_field_full_name", i); 

				this.MembersList.Add (MemberHolder);

			}

			return this.MembersList;
		}


			
	}
}
