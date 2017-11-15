using System;
using Foundation;
using UIKit;

namespace VasSonic.iOS.Demo
{
	public class DemoWebViewController : UIViewController, ISonicSessionDelegate, IUIWebViewDelegate
	{
		private bool isUseSonic;
		private string url;

		public DemoWebViewController(string url, bool isUseSonic)
		{
			this.url = url;
			this.isUseSonic = isUseSonic;
			if (isUseSonic)
			{
				SonicEngine.SharedEngine.CreateSessionWithUrl(url, this);
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			var wb = new UIWebView(this.View.Bounds);
			wb.Delegate = this;
			this.View = wb;
			var request = new NSUrlRequest(new NSUrl(url));
			if (isUseSonic)
			{
				var session = SonicEngine.SharedEngine.SessionWithWebDelegate(this);
				if (session != null)
				{
					wb.LoadRequest(SonicUtil.SonicWebRequestWithSession(session, request));
				}
				else
				{
					wb.LoadRequest(request);
				}
			}
			else
			{
				wb.LoadRequest(request);
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		[Export("sessionWillRequest:")]
		public void SessionWillRequest(SonicSession session)
		{

		}

		[Export("session:requireWebViewReload:")]
		public void Session(SonicSession session, NSUrlRequest request)
		{
			Console.WriteLine(request.Url);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
			SonicEngine.SharedEngine.RemoveSessionWithWebDelegate(this);
		}
	}
}
