
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SPC2010DemoClient
{
	public partial class WebBrowser : UIViewController
	{
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public WebBrowser (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public WebBrowser (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public WebBrowser () : base("WebBrowser", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
		
		#endregion
	}
}

