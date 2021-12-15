
using System;
using MonoTouch.UIKit;

namespace SynPsg.iPhoneUtil
{
	/// <summary>
	/// The NavItem class represents a single navigation item, and will typically be used
	/// to determine what happens when a user clicks on an item in a UITableView that is
	/// hosted within a UINavigationController. The class represents the text label to be
	/// displayed and either an instance of a UIViewController to be displayed when the item
	/// is selected, or the type of a UIViewController to be instantiated and displayed when
	/// the item is selected. In the latter case, "constructor parameters" can also be
	/// specified, which provides a mechanism to pass initialization data to the instantiated
	/// view controller.
	/// </summary>
	
	public class NavItem
	{
		#region Declarations

		/// <summary>
		/// The display text for this NavItem
		/// </summary>		
		public string Text { get; set; }	
		
		/// <summary>
		/// The cell accessory type for this cell
		/// </summary>
		public UITableViewCellAccessory AccessoryType { get; set; }
		
		/// <summary>
		/// The UIViewController that the nav item opens. Use this property if you 
		/// wanted to early instantiate the controller when the nav table is built out,
		/// otherwise just set the Type property and it will lazy-instantiate when the 
		/// nav item is clicked on.
		/// </summary>
		/// 
		
		public UIViewController Controller { get; set; }

		/// <summary>
		/// The Type of the UIViewController. Set this to the type and leave the Controller
		/// property empty to lazy-instantiate the ViewController when the nav item is 
		/// clicked.
		/// </summary>
		
		public Type ControllerType { get; set; }

		/// <summary>
		/// a list of the constructor args (if neccesary) for the controller. use this in
		/// conjunction with ControllerType if lazy-creating controllers.
		/// </summary>

		protected object[] _controllerConstructorArgs = new object[] { };
		
		public object[] ControllerConstructorArgs
		{
			get { return this._controllerConstructorArgs; }
			set
			{
				this._controllerConstructorArgs = value;
				this._controllerConstructorTypes = new Type[this._controllerConstructorArgs.Length];
				for (int i = 0; i < this._controllerConstructorArgs.Length; i++)
				{
					this._controllerConstructorTypes[i] = this._controllerConstructorArgs[i].GetType ();
				}
			}
		}

		/// <summary>
		/// The types of constructor args.
		/// </summary>

		protected Type[] _controllerConstructorTypes = Type.EmptyTypes;

		public Type[] ControllerConstructorTypes
		{
			get
			{
				return this._controllerConstructorTypes;
			}
		}

		#endregion

		#region Constructors

		public NavItem ()
		{
			this.AccessoryType = UITableViewCellAccessory.DisclosureIndicator;
		}

		public NavItem (string text) : this()
		{
			this.Text = text;
		}

		public NavItem (string text, UITableViewCellAccessory accessoryType) : this()
		{
			this.Text = text;
			this.AccessoryType = accessoryType;
		}

		public NavItem (string text, UIViewController controller) : this(text)
		{
			this.Controller = controller;
		}

		public NavItem (string text, UIViewController controller, UITableViewCellAccessory accessoryType) : this(text, accessoryType)
		{
			this.Controller = controller;
		}

		public NavItem (string text, Type controllerType) : this(text)
		{
			this.ControllerType = controllerType;
		}

		public NavItem (string text, Type controllerType, UITableViewCellAccessory accessoryType) : this(text, accessoryType)
		{
			this.ControllerType = controllerType;
		}

		public NavItem (string text, Type controllerType, object[] controllerConstructorArgs) : this(text, controllerType)
		{
			this.ControllerConstructorArgs = controllerConstructorArgs;
		}
		
		public NavItem (string text, Type controllerType, object[] controllerConstructorArgs, UITableViewCellAccessory accessoryType) : this(text, controllerType, accessoryType)
		{
			this.ControllerConstructorArgs = controllerConstructorArgs;
		}
		
		#endregion
	}
}
