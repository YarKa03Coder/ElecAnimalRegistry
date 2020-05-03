using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationOOP
{
    public static class RegexCheck
    {
        public static bool ValidEmail(string email)
        {
            if (new System.Net.Mail.MailAddress(email).Address.Equals(email))
                return true;
            else
                return false;
        }

        public static bool Valid_firstName(string first_name)
        {
            if (String.IsNullOrEmpty(first_name))
                return false;
            else
                return true;

        }

        public static bool Valid_lastName(string last_name)
        {
            if (String.IsNullOrEmpty(last_name))
                return false;
            else
                return true;

        }

        public static bool ValidPassword(string password)
        {
            var password_pattern = "^((?!.*[\\s])(?=.*[A-Z])(?=.*\\d).{7,12})";

            if (Regex.IsMatch(password, password_pattern))
                return true;
            else
                return false;
            //return true;
        }

        public static bool ValidPhone(string phone)
        {
            var phone_pattern = "^\\+?3?8?(0[\\s\\.-]\\d{2}[\\s\\.-]\\d{3}[\\s\\.-]\\d{2}[\\s\\.-]\\d{2})$";

            if (Regex.IsMatch(phone, phone_pattern))
                return true;
            else
                return false;
        }
    }
}
