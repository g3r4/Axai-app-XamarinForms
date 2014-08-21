using System;

namespace Axai
{
	public class Member
	{
		public string Id { get ; set; }
		public string IndexId { get ; set; }
		public string ItemId { get ; set; }
		public string SsFieldBioValue { get ; set; }
		public string SsFieldDrupalUrl { get ; set; }
		public string SsFieldGitUrl { get ; set; }
		public string SsFieldInterestingValue { get ; set; }
		public string SsFieldTwitUrl { get ; set; }
		public string SsFieldUserPictureFileUrl { get ; set; }
		public string SsMail { get ; set; }
		public string SsName { get ; set; }
		public string SsSearchApiLanguage { get ; set; }
		public string SsUid { get ; set; }
		public string SsUrl { get ; set; }
		public string Timestamp { get ; set; }
		public string SsFieldFace { get ; set ; }
		public string SsFieldFlickrUrl { get ; set ; }
		public string SsFieldFullName { get ; set ; }

		public string NameSort
		{
			get
			{
				if (string.IsNullOrWhiteSpace(SsName) || SsName.Length == 0)
					return "?";
				return SsName[0].ToString().ToUpper();
			}
		}
	}
}

