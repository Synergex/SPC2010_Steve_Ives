
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SynPsg.iPhoneUtil;

namespace SPC2010DemoClient
{
	public partial class CustomerScreen : UIViewController
	{
		#region Data definitions

		protected int customerId;
		protected List<NavItem> navItems = new List<NavItem>();
		
		#endregion
		
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for controllers that need 
		// to be able to be created from a xib rather than from managed code

		public CustomerScreen (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public CustomerScreen (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public CustomerScreen (int CustomerId) : base("CustomerScreen", null)
		{
			Initialize ();
			customerId = CustomerId;
		}

		void Initialize ()
		{

		}

		#endregion
		
		#region View lifecycle events
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Configure the navigation controller
			this.NavigationItem.Title = "Customer";
			
			//Populate a collection of NavItem for the datasource
			navItems.Add(new NavItem("Account Summary",typeof(AccountScreen),new object[] { customerId } ));
			navItems.Add(new NavItem("Contacts",typeof(ContactsScreen),new object[] { customerId } ));
			navItems.Add(new NavItem("Locations",typeof(LocationsScreen),new object[] { customerId } ));
			navItems.Add(new NavItem("Open Quotes",typeof(QuotesScreen),new object[] { customerId } ));
			navItems.Add(new NavItem("Open Orders",typeof(OrdersScreen),new object[] { customerId, OrderType.Open } ));
			navItems.Add(new NavItem("Recent Orders",typeof(OrdersScreen),new object[] { customerId, OrderType.Recent } ));
			navItems.Add(new NavItem("Completed Orders",typeof(OrdersScreen),new object[] { customerId, OrderType.Complete } ));
			
			//Create a NavDataSource and bind it to the UITableView control
			TableView.DataSource = new NavDataSource(navItems);
			
			//Hook up the NavDelegate to respond to UITableView events
			TableView.Delegate = new NavDelegate(NavigationController,navItems);	
		}
		
		/*
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}
		*/

		/*
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}
		*/

		/*
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}
		*/
		
		/*
		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
		}
		*/
		
		/*
		public override void ViewDidUnload()
		{
			base.ViewDidUnload();
		}
		*/
				
		#endregion
				
	}
}
