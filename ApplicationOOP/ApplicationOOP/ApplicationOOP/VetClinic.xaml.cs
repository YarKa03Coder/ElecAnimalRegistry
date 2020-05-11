using System;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PermissionStatus = Plugin.Permissions.Abstractions.PermissionStatus;

namespace ApplicationOOP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VetClinic : ContentPage
    {
        private double Longitude { get; set; }
        private double Latitude { get; set; }

        public VetClinic ()
		{
			InitializeComponent ();
            GetPermissionAndStart();
        }

       private async void GetPermissionAndStart()
       {
           try
           {
               var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationPermission>();

               if (status != PermissionStatus.Granted)
               {
                   if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                   {
                       await DisplayAlert("Location", "Allow app use a location of your phone", "OK");
                   }

                   status = await CrossPermissions.Current.RequestPermissionAsync<LocationPermission>();
               }

               if (status == PermissionStatus.Granted)
               {
                   TryOpenMap();
               }
               else if (status != PermissionStatus.Unknown)
               {
                   await DisplayAlert("Location","Location is denied! Please allow it, if you want use Google Maps","Ok");
               }
           }
           catch (Exception ex)
           {
               await DisplayAlert("Location","Something went wrong! Try again","Ok");
           }
       }

       private void TryOpenMap()
       {
           IsInstallApplication installApplication = DependencyService.Get<IsInstallApplication>();
           bool isInstall = installApplication.IsInstall("com.google.android.apps.maps");
           if (isInstall)
           {
               if (IsLocationSet())
               {
                   IMap map = DependencyService.Get<IMap>();
                   map.TryOpenMap(Latitude, Longitude, "Ветеринарные клиники");
               }
               else
               {
                   DisplayAlert("Location", "Geo position is not enabled", "Ok");
               }
           }
           else
           {
               DisplayAlert("Map", "Google Map is not installed", "Ok");
           }

        }

       private async void GetPosition()
       {
           try
           {
               var location = await Geolocation.GetLastKnownLocationAsync() ?? await Geolocation.GetLocationAsync(new GeolocationRequest()
               {
                   DesiredAccuracy = GeolocationAccuracy.Medium,
                   Timeout = TimeSpan.FromSeconds(30)
               });

               if (location == null)
               {
                   throw new Exception();
               }
               else
               {
                   Latitude = location.Latitude;
                   Longitude = location.Longitude;
               }
           }
           catch (Exception exc)
           {
               await DisplayAlert("Maps",$"{exc.Message}","Ok");
           }
       }

       private bool IsLocationSet()
       {
           GetPosition();
           return (Latitude == 0) && (Longitude == 0) ? false : true;
       }

    }
}