using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WebApiHelper.Models;
using static WebApiHelper.HandlingRequests.WebApiHelper;

namespace ApplicationOOP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserPets : ContentPage
	{
        readonly FrontendUserModel _userModel;
        private List<PetModel> _pets = new List<PetModel>();

        public UserPets(FrontendUserModel userModel)
        {
            InitializeComponent();
            this._userModel = userModel;
            GetPets();
        }

        private async void GetPets()
        {
            _pets = await GetUserPetsByEmailAsync(_userModel.Email.ToString());
            if (_pets.Any())
            {
                CarouselView.ItemsSource = _pets;
            }
            else
            {
                await DisplayAlert("User's pets", "No pets are found", "Ok");
            }

        }
    }
}