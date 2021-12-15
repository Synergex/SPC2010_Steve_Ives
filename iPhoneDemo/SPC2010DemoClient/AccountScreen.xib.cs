
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SynPsg.iPhoneUtil;

namespace SPC2010DemoClient
{
	public partial class AccountScreen : UIViewController
	{
		private int customerId;
		
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public AccountScreen (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public AccountScreen (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public AccountScreen (int CustomerId) : base("AccountScreen", null)
		{
			customerId = CustomerId;
			Initialize ();
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
			this.NavigationItem.Title = "Account Summary";

			//Setup fields to resign focus
			Util.SetupTextField(txtEmailTo);
			
			//Put the data in the fields
			lblAccountNumber.Text = customerId.ToString();
			lblCreditLimit.Text = "$25,000.00";
			lblCurrentBalance.Text = "$0.00";
			lblLastOrder.Text = "2010/09/21";
			lblLastPayment.Text = "2010/08/30";
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
		
		partial void btnSendEmail (MonoTouch.UIKit.UIButton sender)
		{
			UiTools.InfoMessage("Sorry!","Emailing account summary has not been implemented yet. Good try though!");
			txtEmailTo.Text="";
		}
	}
}

