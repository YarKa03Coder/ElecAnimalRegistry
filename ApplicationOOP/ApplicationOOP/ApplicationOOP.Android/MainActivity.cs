using System;
using System.Globalization;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;

[assembly: Dependency(typeof(ApplicationOOP.Droid.MainActivity))]
namespace ApplicationOOP.Droid
{
    [Activity(Label = "PetsUA", Icon = "@drawable/logo_image_icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IMap, IsInstallApplication
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
        }

        public void TryOpenMap(double latitude, double longitude, string findOption, bool flagActivity = false)
        {
            Android.Net.Uri intentUri = Android.Net.Uri.Parse
                ($"geo:{latitude.ToString(CultureInfo.InvariantCulture)},{longitude.ToString(CultureInfo.InvariantCulture)}?q={findOption}");

           Android.Content.Intent mapIntent = new Android.Content.Intent(Android.Content.Intent.ActionView, intentUri);
           mapIntent.SetPackage("com.google.android.apps.maps");
           if (flagActivity)
           {
               mapIntent.AddFlags(ActivityFlags.NewTask);
           }
           Android.App.Application.Context.StartActivity(mapIntent);
        }

        public bool IsInstall(string packageName)
        {
            bool installed = false;
            try
            {
                Android.App.Application.Context.PackageManager.GetPackageInfo(packageName, PackageInfoFlags.Activities);
                installed = true;
            }
            catch (PackageManager.NameNotFoundException exc)
            {
                installed = false;
            }

            return installed;
        }
    }
}