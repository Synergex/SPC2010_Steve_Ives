using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using SynPsg.iPhoneUtil;

namespace SPC2010DemoClient
{
	//========================================================================
	//
	// The data source for our Navigation TableView
	//

	public class CustomersDataSource : UITableViewDataSource
	{
		/// <summary>
		/// The collection of Navigation Items that we bind to our Navigation Table
		/// </summary>
		private List<NavItem> navItems;
		//private List<string> sectionTitles;
		/// <summary>
		/// Constructor
		/// </summary>
		public CustomersDataSource()
		{
			navItems = new List<NavItem>();
			foreach (SPC2010.Customer customer in Util.GetCustomersFromDatabase())
				navItems.Add(new NavItem(customer.CustomerName,typeof(CustomerScreen), new object[] { customer.CustomerId } ));
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public CustomersDataSource(string filter)
		{
			navItems = new List<NavItem>();
			foreach (SPC2010.Customer customer in Util.GetCustomersFromDatabase(filter))
				navItems.Add(new NavItem(customer.CustomerName,typeof(CustomerScreen), new object[] { customer.CustomerId } ));
		}

		/// <summary>
		/// Called by the TableView to determine how man cells to create for that particular section.
		/// </summary>
		public override int RowsInSection (UITableView tableView, int section)
		{
			return navItems.Count;
		}

		/// <summary>
		/// Called by the TableView to actually build each cell. 
		/// </summary>

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			//Declare vars
			string cellIdentifier = "SimpleCellTemplate";
			
			//Try to grab a cell object from the internal queue
			var cell = tableView.DequeueReusableCell(cellIdentifier);

			//If there aren't any available, just create a new one
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

			//Set the cell properties
			cell.TextLabel.Text = NavItems[indexPath.Row].Text;
			cell.Accessory = navItems[indexPath.Row].AccessoryType;
			
			//Return the cell
			return cell;
		}
		
		public List<NavItem> NavItems
		{
			get
			{
				return navItems;
			}
		}
		
		/*
		
		these should enable row swipt to delete, but it doesn't seem to work.
		I suspect I may need to combine my Data Source and my Delegate into a 
		single class using UITableViewSource (instead of UITableViewDataSource)
		
		public override bool CanEditRow(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			return true;
		}
		
		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			navItems.RemoveAt(indexPath.Row);
			tableView.DeleteRows(
				new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
		}
		
		public override string TitleForDeleteConfirmation(UITableView UITableView, NSIndexPath NSIndexPath)
		{
			return "Delete Customer";
		}
		*/
		
	}
}