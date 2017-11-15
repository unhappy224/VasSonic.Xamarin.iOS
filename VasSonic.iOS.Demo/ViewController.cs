using System;
using CoreGraphics;
using UIKit;

namespace VasSonic.iOS.Demo
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{

		}

		public override void ViewDidLoad()
		{
			var btn_sonic = new UIButton(new CGRect(100, 100, 200, 44));
			btn_sonic.SetTitle("使用VasSonic", UIControlState.Normal);
			btn_sonic.SetTitleColor(UIColor.Orange, UIControlState.Normal);
			btn_sonic.TouchUpInside += (_, __) =>
			{
				this.NavigationController.PushViewController(new DemoWebViewController("http://mc.vip.qq.com/demo/indexv3", true), true);
			};
			View.Add(btn_sonic);

			var btn_direct = new UIButton(new CGRect(100, 200, 200, 44));
			btn_direct.SetTitle("不使用VasSonic", UIControlState.Normal);
			btn_direct.SetTitleColor(UIColor.Orange, UIControlState.Normal);
			btn_direct.TouchUpInside += (_, __) =>
			{
				this.NavigationController.PushViewController(new DemoWebViewController("http://mc.vip.qq.com/demo/indexv3", false), true);
			};
			View.Add(btn_direct);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


	}
}
