using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace SynPsg.iPhoneUtil
{
	//========================================================================
	//
	// The data source for our Navigation TableView
	//

	public class NavDataSource : UITableViewDataSource
	{
		/// <summary>
		/// The collection of Navigation Items that we bind to our Navigation Table
		/// </summary>
		protected List<NavItem> navItems;
		
		/// <summary>
		/// Constructor
		/// </summary>
		public NavDataSource (List<NavItem> NavItems)
		{
			navItems = NavItems;
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
			cell.TextLabel.Text = navItems[indexPath.Row].Text;
			cell.Accessory = navItems[indexPath.Row].AccessoryType;
			
			//Return the cell
			return cell;
		}
	}
}