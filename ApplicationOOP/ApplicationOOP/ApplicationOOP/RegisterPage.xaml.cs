using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static WebApiHelper.HandlingRequests.WebApiHelper;



namespace ApplicationOOP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private IColorful colorful_register;

        public RegisterPage ()
		{
			InitializeComponent();
            colorful_register = new ChangeColor(this);
            InitColors();
            InputInfo();
		}

        private void InitColors()
        {
            BackgroundColor = colorful_register.SetBackgroundColor(Color.FromRgb(58, 153, 215));
            Lbl_FirstName.TextColor = colorful_register.SetTextColor(Color.White);
            Lbl_LastName.TextColor = colorful_register.SetTextColor(Color.White); 
            Lbl_Phone.TextColor = colorful_register.SetTextColor(Color.White);
            Lbl_email.TextColor = colorful_register.SetTextColor(Color.White);
            Lbl_Password.TextColor = colorful_register.SetTextColor(Color.White); 
            Lbl_Phone.TextColor = colorful_register.SetTextColor(Color.White);
            Lbl_Confirm.TextColor = colorful_register.SetTextColor(Color.White);
            Btn_Signup.BackgroundColor = colorful_register.SetButtonColor(Color.White);
            Btn_Signup.TextColor = colorful_register.SetTextColor(Color.Gray);
        }

        private void InputInfo()
        {
            Entry_FirstName.Completed += (s, e) => Entry_LastName.Focus();
            Entry_LastName.Completed += (s, e) => EntryPhone.Focus();
            EntryPhone.Completed += (s, e) => Entry_email.Focus();
            Entry_email.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => Entry_PassConfirm.Focus();
            Entry_PassConfirm.Completed += (s, e) => SignUpProcedure(s, e);
        }

        private async void SignUpProcedure(object sender, EventArgs e)
        {
            if (Check())
            {
                if (ConnectionCheck.CheckForInternetConnection())
                {
                    // REGISTRATION REQUEST
                    if (await RegisterUserAsync(new FilledUser(this).InputInfo()))
                    {
                        Navigation.RemovePage(this);
                        await Navigation.PushModalAsync(new LoginPage());
                    }
                }
                else
                    await DisplayAlert("Sign Up", "Check your internet connection", "Ok");
            }
            else
                await DisplayAlert("Sign Up", "Something went wrong. Please try again", "Ok");
        }

        private bool Check()
        {
            if(!RegexCheck.Valid_firstName(Entry_FirstName.Text) && !RegexCheck.Valid_lastName(Entry_LastName.Text))
            {
                if(RegexCheck.ValidEmail(Entry_email.Text) && RegexCheck.ValidPhone(EntryPhone.Text))
                {
                    if(RegexCheck.ValidPassword(Entry_Password.Text) && RegexCheck.ConfirmPassword(Entry_PassConfirm.Text, Entry_Password))
                    {
                        return true;
                    }
                    else
                    {
                        DisplayAlert("Registration", "Password is wrong", "Ok");
                        Entry_PassConfirm.Text = String.Empty;
                        return false;
                    }
                }
                else
                { DisplayAlert("Registration", "Check e-mail and phone number again", "Ok"); return false; }
            }
            else
            { DisplayAlert("Registration", "First name or Last name can not be empty", "Ok"); return false;}
        }
    }
}