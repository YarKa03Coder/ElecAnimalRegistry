using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            Entry_Password.Completed += (s, e) => LogInProcedure(s, e);
        }

        private void LogInProcedure(object sender, EventArgs e)
        {
            /*if (RegexCheck.ValidEmail(Entry_email.Text) && RegexCheck.ValidPassword(Entry_Password.Text))
            {
                // LOGIN REQUEST
                FrontendUserModel user = LogUserInAsync(Entry_email.ToString(), Entry_Password.ToString());
                if (!user.Equals(null))
                {
                    //it's just a stub, a new page with info will appear if success
                    Navigation.PushModalAsync(new StubPage());
                }
                else
                    DisplayAlert("Login", "Such user was not found", "Ok");
            }
            else
                DisplayAlert("Login", "E-mail or Password is wrong. Please check and try again", "Ok");
            // if user does not remember, need some mechanism to reset the password*/
        }
    }
}