using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SchrackPOC.Droid
{
    [Activity(Label = "SchrackPOC", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Couchbase.Lite.Support.Droid.Activate(this);
            LoadApplication(new App());
        }

        public override void OnActionModeStarted(ActionMode mode)
        {
            IMenu menu = mode.Menu;
            menu.Clear();
            base.OnActionModeStarted(mode);
        }
    }
}