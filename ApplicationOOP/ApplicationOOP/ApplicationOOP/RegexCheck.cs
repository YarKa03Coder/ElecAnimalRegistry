using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ApplicationOOP
{
    public static class RegexCheck
    {
        public static bool ValidEmail(string email)
        {
            return new System.Net.Mail.MailAddress(email).Address.Equals(email);
        }

        public static bool Valid_firstName(string first_name)
        {
            return String.IsNullOrEmpty(first_name);
        }

        public static bool Valid_lastName(string last_name)
        {
            return String.IsNullOrEmpty(last_name);
        }

        public static bool ValidPassword(string password)
        {
            var password_pattern = "^((?!.*[\\s])(?=.*[A-Z])(?=.*\\d).{7,12})";

            return Regex.IsMatch(password, password_pattern);
        }

        public static bool ValidPhone(string phone)
        {
            var phone_pattern = "^\\+?3?8?(0[\\s\\.-]\\d{2}[\\s\\.-]\\d{3}[\\s\\.-]\\d{2}[\\s\\.-]\\d{2})$";

            return Regex.IsMatch(phone, phone_pattern);
        }

        public static bool ConfirmPassword(string passwordconfirm, Entry entred_password)
        {
            return passwordconfirm.Equals(entred_password.Text);
        }
    }
}
