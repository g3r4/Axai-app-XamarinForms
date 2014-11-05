//
//  Member.cs
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

