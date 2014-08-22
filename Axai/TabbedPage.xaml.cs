using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Axai
{	
	public partial class TabbedAxai
	{	
		public TabbedAxai ()
		{
			//this.IsBusy=true;

			InitializeComponent ();

			this.Children.Add(new MembersPage ());
		}
	}
}

