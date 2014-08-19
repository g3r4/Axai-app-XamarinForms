using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Axai
{	
	public partial class TabbedAxai
	{	

		public MemberRecordManager MemberRM = new MemberRecordManager();

		public static List <Member> MembersList = new List<Member> ();

		private string json="";

		public TabbedAxai ()
		{
			InitializeComponent ();

		}
		protected override async void OnAppearing(){

			json = await MemberRM.GetJsonFromDrupalAsync (MemberRM.MembersIndexJsonURIProperty);
			MembersList = MemberRM.DeserializeJsonToMemberList (json);
			await this.DisplayAlert ("JSON", MembersList[0].SsName, "OK", null);
		}
	}
}

