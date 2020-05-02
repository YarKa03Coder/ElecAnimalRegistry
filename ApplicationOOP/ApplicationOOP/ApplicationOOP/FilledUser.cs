using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ApplicationOOP
{
    class FilledUser
    {
        private Page page;
        private RegisterUserModel user;

        public FilledUser(Page page)
        {
            this.page = page;
        }

        public RegisterUserModel InputInfo()
        {
            user.FirstName = page.FindByName("Entry_FirstName").ToString();
            user.LastName = page.FindByName("Entry_LastName").ToString();
            user.Phone = page.FindByName("EntryPhone").ToString();
            user.Email = page.FindByName("Entry_email").ToString();
            user.Password = page.FindByName("Entry_Password").ToString();

            return user;
        }
    }
}
