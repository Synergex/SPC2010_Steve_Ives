
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SynPsg.iPhoneUtil;

namespace SPC2010DemoClient
{
	public partial class AddressScreen : UIViewController
	{
		#region Data definitions

		protected SPC2010.Address address;
		
		#endregion

		#region Constructors

		// The IntPtr and initWithCoder constructors are required for controllers that need 
		// to be able to be created from a xib rather than from managed code

		public AddressScreen (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public AddressScreen (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public AddressScreen (SPC2010.Address Address) : base("AddressScreen", null)
		{
			Initialize ();
			address = Address;
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
			this.NavigationItem.Title = "Location";

			//Setup the text fields to be able to resign focus
			Util.SetupTextField(txtStreet);
			Util.SetupTextField(txtCity);
			Util.SetupTextField(txtState);
			Util.SetupTextField(txtZip);

			//Put the data in the text fields
			txtStreet.Text = address.Street;
			txtCity.Text = address.City;
			txtState.Text = address.State;
			txtZip.Text = address.Zip;
			
			btnShowMap.TouchUpInside += delegate {
				
				if (AppTools.CantRunOnSimulator())
					return;
				
				UiTools.InfoMessage("Sorry!","Location mapping has not been implemented yet. Good try though!");				
			};
			
			btnSave.TouchUpInside += delegate {
				UiTools.InfoMessage("Sorry!","Updating addresses has not been implemented yet. Good try though!");				
			};
			
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
