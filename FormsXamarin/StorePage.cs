using System;

using Xamarin.Forms;

namespace FormsXamarin
{
    public class StorePage : ContentPage
    {
        public StorePage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

