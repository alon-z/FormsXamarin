using System;
using Xamarin.Forms;

namespace FormsXamarin.Objects
{
    public class Page
    {
        string longText { get; }
        ImageSource image { get; }
        string subtext { get; }

        public Page(string longText, string subtext)
        {
            this.longText = longText;
            this.subtext = subtext;
            this.image = null;
        }

        public Page(ImageSource image, string subtext)
        {
            this.image = image;
            this.subtext = subtext;
            this.longText = null;
        }
    }
}
