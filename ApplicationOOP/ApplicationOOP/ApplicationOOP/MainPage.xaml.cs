using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ApplicationOOP
{
    public partial class MainPage : ContentPage
    {
        private IColorful colorful;
        public MainPage()
        {
            InitializeComponent();
            colorful = new ChangeColor(this);
            InitColors();
        }

        private void InitColors()
        {
            Btn_LogIn.TextColor = colorful.SetTextColor(Color.White);
            Btn_SignUp.TextColor = colorful.SetTextColor(Color.White);
            Btn_LogIn.BackgroundColor = colorful.SetButtonColor(Color.Gray);
            Btn_SignUp.BackgroundColor = colorful.SetButtonColor(Color.Gray);
            BackgroundColor = colorful.SetBackgroundColor(Color.White);
        }

        private void LogInClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void SignUpClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
