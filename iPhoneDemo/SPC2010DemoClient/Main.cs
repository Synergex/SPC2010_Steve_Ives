
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SynPsg.iPhoneUtil;

namespace SPC2010DemoClient
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}

	// The name AppDelegate is referenced in the MainWindow.xib file.

	public partial class AppDelegate : UIApplicationDelegate
	{
		//Collection of NavItem objects for the data source of the UITableView
		protected List<NavItem> navItems = new List<NavItem>();

		// This method is invoked when the application has loaded its UI and its ready to run
	
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			//Make sure the database exists. This will also load customers into the database.
			Util.CheckDatabase();
			
			//Provide the UITableView with Customer data
			CustomersDataSource ds = new CustomersDataSource();
			TableView.DataSource = ds;

			//Hook up the NavDelegate to respond to UITableView events
			TableView.Delegate = new NavDelegate(NavigationController,ds.NavItems);

			//Hook up a delegate to the UISearchDisplayController
			SearchController.Delegate = new CustomersSearchDelegate();

			//Store the main navigation controller in a static so it can be used
			//elsewhere. Specifically it is used by CustomerSearchDelegate
			Util.NavController = NavigationController;
			
			// If you have defined a view, add it here:
			window.AddSubview (NavigationController.View);
			window.MakeKeyAndVisible ();

			return true;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
		
		partial void btnRefreshClick (MonoTouch.UIKit.UIBarButtonItem sender)
		{
			Util.RefreshCustomers();
			navItems.Clear();
			
			foreach (SPC2010.Customer customer in Util.GetCustomersFromDatabase())
				navItems.Add(new NavItem(customer.CustomerName,typeof(CustomerScreen), new object[] { customer.CustomerId } ));
			//Create a NavDataSource and bind it to the UITableView control
			TableView.DataSource = new NavDataSource(navItems);

			//Hook up the NavDelegate to respond to UITableView events
			TableView.Delegate = new NavDelegate(NavigationController,navItems);
		}
	
		partial void btnAddClick (MonoTouch.UIKit.UIBarButtonItem sender)
		{
			UiTools.InfoMessage("Sorry!","Adding new customers has not been implemented yet. Good try though!");
		}

		partial void btnEditClick (MonoTouch.UIKit.UIBarButtonItem sender)
		{
			UiTools.InfoMessage("Sorry!","Editing customers has not been implemented yet. Good try though!");
		}

	}
}
