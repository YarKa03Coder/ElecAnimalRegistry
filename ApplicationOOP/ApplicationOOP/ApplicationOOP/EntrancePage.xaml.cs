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
	public partial class EntrancePage : MasterDetailPage
	{
		public EntrancePage ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new UserPets());
            IsPresented = false;
        }

        private void User_animals(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new UserPets());
            IsPresented = false;
        }

        private void Find_owner(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new FindOwner());
            IsPresented = false;
        }

        private void Veterinar_clinic(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new VetClinic());
            IsPresented = false;
        }

        private void Log_out(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
            IsPresented = false;
        }
    }
}