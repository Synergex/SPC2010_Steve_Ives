using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SynPsg.iPhoneUtil
{
	public static class AppTools
	{
		public static bool CantRunOnSimulator()
		{
			if (UIDevice.CurrentDevice.LocalizedModel.Equals("iPhone Simulator"))
			{
				UiTools.InfoMessage("Not Supported by Simulator","This operation is not supported by the iPhone simulator. This feature should be tested on a physical device prior to release.");
				return true;
			}
			return false;
		}
		
		public static void MakePhoneCall(string number)
		{
			if (CantRunOnSimulator())
				return;

			try
			{
				NSUrl url = NSUrl.FromString(String.Format("tel:{0}",number));
				if (!UIApplication.SharedApplication.OpenUrl(url))
					UiTools.ErrorMessage("Error","Failed to make call!");
			}
			catch (Exception ex)
			{
				UiTools.ErrorMessage("Error Launching Phone",ex.Message);
			}
		}
		
		public static void LaunchBrowser(string webAddress)
		{
			if (CantRunOnSimulator())
				return;
			
			try
			{
				NSUrl url = NSUrl.FromString(webAddress);
				if (!UIApplication.SharedApplication.OpenUrl(url))
						UiTools.ErrorMessage("Error","Failed to launch browser!");
			}
			catch (Exception ex)
			{
				UiTools.ErrorMessage("Error Launching Browser",ex.Message);
			}
		}
		
		public static void LaunchEmailMessage(string emailAddress)
		{
			if (CantRunOnSimulator())
				return;
			
			try
			{
				NSUrl url = NSUrl.FromString(String.Format("mailto:{0}",emailAddress));
				if (!UIApplication.SharedApplication.OpenUrl(url))
					UiTools.ErrorMessage("Error","Failed to launch email!");
			}
			catch (Exception ex)
			{
				UiTools.ErrorMessage("Error Launching Email",ex.Message);
			}
		}
		
	}
}

