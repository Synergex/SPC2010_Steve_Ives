using System;
using MonoTouch.UIKit;

namespace SynPsg.iPhoneUtil
{
	
	[Flags]
	internal enum MessageBoxButton
	{
		OK = 1,
		Cancel = 2
	};
	
	public static class UiTools
	{
		public static void InfoMessage(string message)
		{
			MessageBox("Information",message,MessageBoxButton.OK);
		}
		
		public static void InfoMessage(string title, string message)
		{
			MessageBox(title,message,MessageBoxButton.OK);
		}
		
		public static void ErrorMessage(string message)
		{
			MessageBox("Error",message,MessageBoxButton.OK);
		}		
		
		public static void ErrorMessage(string title, string message)
		{
			MessageBox(title,message,MessageBoxButton.OK);
		}		
		
		internal static void MessageBox(string title, string message, MessageBoxButton buttons)
		{
			using(UIAlertView alert = new UIAlertView())
			{
				alert.Title = title;
				alert.Message = message;
				if((buttons & MessageBoxButton.OK) == MessageBoxButton.OK)
					alert.AddButton("OK");
				if((buttons & MessageBoxButton.Cancel) == MessageBoxButton.Cancel)
					alert.AddButton("Cancel");
				alert.Show();
			}
		}

	}
}

