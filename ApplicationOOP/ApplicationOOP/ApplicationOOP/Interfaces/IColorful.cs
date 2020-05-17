using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ApplicationOOP
{
    public interface IColorful
    {
        Color Background { get; }
        Color Button { get; }
        Color Text { get; }
        Color SetBackgroundColor(Color color);
        Color SetTextColor(Color color);
        Color SetButtonColor(Color color);
    }
}
