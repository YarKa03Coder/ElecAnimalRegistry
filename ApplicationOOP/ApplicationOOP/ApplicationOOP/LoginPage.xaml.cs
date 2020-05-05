using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WebApiHelper.Models;
using WebApiHelper.HandlingRequests;

namespace ApplicationOOP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public IColorful colorful_login;

        public LoginPage()
        {
            InitializeComponent();
            colorful_login = new ChangeColor(this);
            InitColors();
            InputInfo();
        }

        private void InitColors()
        {
            BackgroundColor = colorful_login.SetBackgroundColor(Color.FromRgb(58, 153, 215));
            Lbl_email.TextColor = colorful_login.SetTextColor(Color.White);
            Lbl_Password.TextColor = colorful_login.SetTextColor(Color.White);
            Btn_LogIn.BackgroundColor = colorful_login.SetButtonColor(Color.White);
            Btn_LogIn.TextColor = colorful_login.SetTextColor(Color.Gray);
        }

        private void InputInfo()
        {
            Entry_email.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += async (s, e) => LogInProcedure(s, e);
        }

        private async void LogInProcedure(object sender, EventArgs e)
        {
            if (ConnectionCheck.CheckForInternetConnection())
            {
                // LOGIN REQUEST
                FrontendUserModel user = await LogUserInAsync(Entry_email.Text, Entry_Password.Text);
                if (!user.Equals(null))
                {
                    //it's just a stub, a new page with info will appear if success
                    await Navigation.PushModalAsync(new StubPage());
                }
                else
                    await DisplayAlert("Login", "Such user is not found", "Ok");
            }
            else
                await DisplayAlert("Login", "Check your internet connection", "Ok");
        }                 
    }
}