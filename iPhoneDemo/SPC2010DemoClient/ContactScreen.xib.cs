
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SynPsg.iPhoneUtil;

namespace SPC2010DemoClient
{
	public partial class ContactScreen : UIViewController
	{
		#region Data definitions

		protected SPC2010.Contact contact;
		
		#endregion

		#region Constructors

		// The IntPtr and initWithCoder constructors are required for controllers that need 
		// to be able to be created from a xib rather than from managed code

		public ContactScreen (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public ContactScreen (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public ContactScreen (SPC2010.Contact Contact) : base("ContactScreen", null)
		{
			Initialize ();
			contact = Contact;
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
			this.NavigationItem.Title = "Contact";

			//Setup the text fields to be able to resign focus
			Util.SetupTextField(txtFirstName);
			Util.SetupTextField(txtLastName);
			Util.SetupTextField(txtWorkPhone);
			Util.SetupTextField(txtHomePhone);
			Util.SetupTextField(txtEmail);

			//Put the data in the text fields
			txtFirstName.Text = contact.FirstName;
			txtLastName.Text = contact.LastName;
			txtWorkPhone.Text = contact.WorkPhone;
			txtHomePhone.Text = contact.HomePhone;
			txtEmail.Text = contact.Email;
			
			btnCallHome.Enabled = ((txtHomePhone.Text!=null) && (txtHomePhone.Text.Length > 0));
			btnCallWork.Enabled = ((txtWorkPhone.Text!=null) && (txtWorkPhone.Text.Length > 0));
			btnEmail.Enabled = ((txtEmail.Text!=null) && (txtEmail.Text.Length > 0));

			btnSave.TouchUpInside += delegate {
				UiTools.InfoMessage("Sorry!","Updating contacts has not been implemented yet. Good try though!");
			};
			
			btnCallHome.TouchUpInside += delegate {
				if (AppTools.CantRunOnSimulator())
					return;
				AppTools.MakePhoneCall(txtHomePhone.Text);
			};

			btnCallWork.TouchUpInside += delegate {
				if (AppTools.CantRunOnSimulator())
					return;
				AppTools.MakePhoneCall(txtWorkPhone.Text);				
			};
			
			btnEmail.TouchUpInside += delegate {
				if (AppTools.CantRunOnSimulator())
					return;
				AppTools.LaunchEmailMessage(txtEmail.Text);				
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
