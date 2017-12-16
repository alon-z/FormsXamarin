using System;

using Xamarin.Forms;

namespace FormsXamarin
{
    public class Tabs : TabbedPage
    {
        public Tabs()
        {
            var storyPage = new StoryPage();
            storyPage.Title = "Story";
            var storePage = new StorePage();
            storePage.Title = "Book Store";
            Children.Add(storyPage);
            Children.Add(storePage);
        }
    }
}

