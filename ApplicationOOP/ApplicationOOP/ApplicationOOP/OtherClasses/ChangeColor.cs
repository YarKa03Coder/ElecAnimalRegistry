using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ApplicationOOP
{
    class ChangeColor : IColorful
    {
        public Color Background { get; private set; }
        public Color Button { get; private set; }
        public Color Text { get; private set; }
        private Page page;

        public ChangeColor(Page page)
        { this.page = page; }

        public Color SetBackgroundColor(Color background)
        {
            this.Background = background;
            return Background;
        }

        public Color SetTextColor(Color text)
        {
            this.Text = text;
            return Text;
        }

        public Color SetButtonColor(Color button)
        {
            this.Button = button;
            return Button;
        }
    }
}
