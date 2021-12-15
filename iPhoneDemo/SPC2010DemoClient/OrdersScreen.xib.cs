
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SynPsg.iPhoneUtil;

namespace SPC2010DemoClient
{
	public enum OrderType
	{
		Recent,
		Open,
		Complete
	}
	
	public partial class OrdersScreen : UIViewController
	{
		#region Data definitions

		//private int customerId;
		private OrderType orderType;
		protected List<NavItem> navItems = new List<NavItem>();
		
		#endregion
		
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public OrdersScreen (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public OrdersScreen (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public OrdersScreen (int CustomerId, OrderType oType) : base("OrdersScreen", null)
		{
			Initialize ();
			//customerId = CustomerId;
			orderType = oType;
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
			
			switch (orderType)
			{
				case OrderType.Open:
					this.NavigationItem.Title = "Open Orders";
					break;				
				case OrderType.Recent:
					this.NavigationItem.Title = "Recent Orders";
					break;				
				case OrderType.Complete:
					this.NavigationItem.Title = "Completed Orders";
					break;									
			}

			//Get a collection of customer orders from the web service
			//SPC2010.SPC2010WebService svc = new SPC2010.SPC2010WebService();
			//SPC2010.Address[] addresses = svc.GetCustomerAddresses(customerId);
			//svc.Dispose();

			//Populate a collection of NavItem for the datasource
			//string addressLabel;
			//foreach (SPC2010.Address address in addresses)
			//{
			//	addressLabel = address.City + ", " + address.State;
			//	navItems.Add(new NavItem(addressLabel,typeof(AddressScreen),new object[] { address } ));
			//}
			
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

