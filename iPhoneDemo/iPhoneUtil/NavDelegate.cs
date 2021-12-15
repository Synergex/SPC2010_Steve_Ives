using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SynPsg.iPhoneUtil
{
	//
	// This class receives notifications that happen on the UITableView
	//

	public class NavDelegate : UITableViewDelegate
	{
		//---- declare vars
		UINavigationController navigationController;
		List<NavItem> navItems;

		/// <summary>
		/// Constructor
		/// </summary>
		public NavDelegate (UINavigationController NavigationController, List<NavItem> NavItems)
		{
			navigationController = NavigationController;
			navItems = NavItems;
		}
			
		/// <summary>
		/// Is called when a row is selected
		/// </summary>
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			//---- get a reference to the nav item
			NavItem navItem = navItems[indexPath.Row];
	
			//---- if the nav item has a proper controller, push it on to the NavigationController
			// NOTE: we could also raise an event here, to loosely couple this, but isn't neccessary,
			// because we'll only ever use this this way
			if (navItem.Controller != null)
			{
				navigationController.PushViewController(navItem.Controller, true);
	
				//---- show the nav bar (we don't show it on the home page)
				navigationController.NavigationBarHidden = false;
			}
			else if (navItem.ControllerType != null)
			{
				ConstructorInfo ctor = null;
	
				//---- if the nav item has constructor aguments
				if (navItem.ControllerConstructorArgs.Length > 0)
				{
					//---- look for the constructor
					ctor = navItem.ControllerType.GetConstructor(navItem.ControllerConstructorTypes);	
				}
				else
				{
					//---- search for the default constructor
					ctor = navItem.ControllerType.GetConstructor(System.Type.EmptyTypes);
				}


				//---- if we found the constructor
				if (ctor != null)
				{
					UIViewController instance = null;

					if (navItem.ControllerConstructorArgs.Length > 0)
					{
						//---- instance the view controller
						instance = ctor.Invoke(navItem.ControllerConstructorArgs) as UIViewController;	
					}
					else
					{
						//---- instance the view controller
						instance = ctor.Invoke(null) as UIViewController;
					}

					if (instance != null)
					{
						//---- save the object
						navItem.Controller = instance;

						//---- push the view controller onto the stack
						navigationController.PushViewController(navItem.Controller, true);
					}
					else
						Console.WriteLine ("Instance of view controller not created");

				}
				else
					Console.WriteLine ("Constructor not found");
			}
		}

		/// <summary>
		/// This event handler fires if the TableView row is in DetailDisclosureButton mode and
		/// the user taps on the button. If the user taps on the item OUTSIDE the button then the
		/// RowSelected event fires.
		/// </summary>
		/// <param name="tableView">
		/// A <see cref="UITableView"/>
		/// </param>
		/// <param name="indexPath">
		/// A <see cref="NSIndexPath"/>
		/// </param>
		
		public override void AccessoryButtonTapped (UITableView tableView, NSIndexPath indexPath)
		{
			RowSelected(tableView, indexPath);
		}

	}
}
