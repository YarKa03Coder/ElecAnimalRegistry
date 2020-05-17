using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using WebApiHelper.Models;

namespace ApplicationOOP
{
    class FilledUser
    {
        private Page page;
        private RegisterUserModel user;

        public FilledUser(Page page)
        {
            this.page = page;
            user = new RegisterUserModel();
        }

        public RegisterUserModel InputInfo()
        {
            user.FirstName = page.FindByName<Entry>("Entry_FirstName").Text;
            user.LastName = page.FindByName<Entry>("Entry_LastName").Text;
            user.Phone = page.FindByName<Entry>("EntryPhone").Text;
            user.Email = page.FindByName<Entry>("Entry_email").Text;
            user.Password = page.FindByName<Entry>("Entry_Password").Text;

            return user;
        }
    }
}
