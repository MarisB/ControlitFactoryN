using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace ControlitFactory.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            // Color of the tabbar background:
            //UITabBar.Appearance.BackgroundColor = Color.FromHex("#EAAA00").ToUIColor();

            //// Color of the selected tab text color:
            //UITabBarItem.Appearance.SetTitleTextAttributes(
                //new UITextAttributes()
                //{
                //    TextColor = UIColor.FromRGB(0, 122, 255),
                //    Font = UIFont.SystemFontOfSize(20.0f, UIFontWeight.Bold)
                //},
                //UIControlState.Selected);

            global::Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.Init();
            global::FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            global::FFImageLoading.ImageService.Instance.Initialize(new FFImageLoading.Config.Configuration()
            {
                Logger = new ControlitFactory.Services.DebugLogger()
            });

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
