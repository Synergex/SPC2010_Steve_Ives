using System;
using MonoTouch.UIKit;
using SynPsg.iPhoneUtil;

namespace SPC2010DemoClient
{
	//[MonoTouch.Foundation.Register("CustomersSearchDelegate")]
	public class CustomersSearchDelegate : UISearchDisplayDelegate
	{
		public override bool ShouldReloadForSearchString (UISearchDisplayController controller, string filter)
		{
			Console.WriteLine("In ShouldReloadForSearchString");
			
			CustomersDataSource ds = new CustomersDataSource(filter);
			
			controller.SearchResultsDataSource = ds;
			controller.SearchResultsDelegate = new NavDelegate(Util.NavController,ds.NavItems);

			return true;
		}
	}
}
