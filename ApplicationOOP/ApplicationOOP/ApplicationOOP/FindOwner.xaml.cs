using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiHelper.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static WebApiHelper.HandlingRequests.WebApiHelper;

namespace ApplicationOOP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FindOwner : ContentPage
    {
        private FrontendUserModel _frontendUser;
        private FormattedString _phoneFormattedString;
        private FormattedString _emailFormattedString;

        public FindOwner ()
		{
			InitializeComponent ();
            FrameOwner.IsVisible = false;
        }

        private async void StartFindingUser(object sender, EventArgs e)
        {
            var keyword = UserSearchBar.Text;
            if (Int32.TryParse(keyword,out var petId))
            {
                FrameOwner.IsVisible = true;
                _frontendUser = await GetUserByPetIDAsync(petId);
                if (_frontendUser != null)
                {
                    InitializeLables();
                    CreateFrame_user();
                }
                else
                {
                    CreateFrame_user(true);
                }
            }
            else
            {
                await DisplayAlert("Find User","Input an integer into search field","Ok");
            }

        }

        private void InitializeLables()
        {
            _phoneFormattedString = new FormattedString();
            _emailFormattedString = new FormattedString();

            var span_phone = new Span(){Text = _frontendUser.Phone};
            var span_email = new Span(){Text = _frontendUser.Email};
            span_email.GestureRecognizers.Add(new TapGestureRecognizer
                {Command = new Command(async () => await DisplayAlert("Tapped","This is email","Ok"))});
            span_phone.GestureRecognizers.Add(new TapGestureRecognizer
                {Command = new Command(async () => await DisplayAlert("Tapped", "This is phone", "Ok"))});


            _phoneFormattedString.Spans.Add(
                new Span(){Text = "Phone: "});
            _phoneFormattedString.Spans.Add(span_phone);

            _emailFormattedString.Spans.Add(
                new Span(){Text = "E-mail: "});
            _emailFormattedString.Spans.Add(span_email);
        }

        private void CreateFrame_user(bool empty = false)
        {
            if (empty)
            {
                FrameOwner.Content = new StackLayout()
                {
                    Children =
                    {
                        new Label()
                        {
                            Text = "Pet Owner",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            FontAttributes = FontAttributes.Bold,
                            HorizontalOptions = LayoutOptions.Center
                        },
                        new BoxView
                        {
                            Color = Color.Gray,
                            HeightRequest = 2,
                            HorizontalOptions = LayoutOptions.Fill
                        },
                        new Label
                        {
                            Text = "Such user is not found!!!",
                            HorizontalOptions = LayoutOptions.Center
                        }
                    }
                };
            }
            else
            {
                FrameOwner.Content = new StackLayout()
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "Pet Owner",
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            FontAttributes = FontAttributes.Bold,
                            HorizontalOptions = LayoutOptions.Center
                        },
                        new BoxView
                        {
                            Color = Color.Gray,
                            HeightRequest = 10,
                            HorizontalOptions = LayoutOptions.Fill
                        },
                        new Label()
                        {
                            Text = $"First Name: {_frontendUser.FirstName}",
                            HorizontalOptions =  LayoutOptions.Center
                        },
                        new Label()
                        {
                            Text = $"Last Name: {_frontendUser.LastName}",
                            HorizontalOptions =  LayoutOptions.Center
                        },
                        new Label()
                        {
                            FormattedText = _emailFormattedString,
                            HorizontalOptions =  LayoutOptions.Center
                        },
                        new Label()
                        {
                            FormattedText = _phoneFormattedString,
                            HorizontalOptions =  LayoutOptions.Center
                        }
                    }
                };
            }
        }
	}
}