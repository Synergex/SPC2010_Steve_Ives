
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SPC2010DemoClient
{
	public partial class TestView : UIViewController
	{
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public TestView (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public TestView (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public TestView () : base("TestView", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
		
		#endregion
	}
}

