using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsXamarin
{
    public class StoryPage : ContentPage
    {
        async Task AutoScrol (ScrollView view, double position) {
            await Task.Delay(1);
            await view.ScrollToAsync(0, position, true);
            if (position < view.Height)
                await AutoScrol(view, position + 7);
        }

        public StoryPage()
        {
            // Page pref
            Thickness thickness = new Thickness(20, 10, 20, 20);
            if (Device.RuntimePlatform == Device.iOS)
                thickness.Top += 20; // Add padding to page on iOS
            this.Padding = thickness;
            //BackgroundColor = Color.DarkMagenta;

            // Create the scrollview for the long text area
            ScrollView longTextScrollView = new ScrollView();
            Label longText = new Label();
            longText.FontSize = 30;
            //longText.Text = "Lorem ipsum dolor sit amet, sed suscipit mauris lorem non quis id, orci volutpat porta amet est urna integer, feugiat semper at lorem aliquam ut quis, suscipit pellentesque odio felis ac malesuada sem. Magna magna enim aenean maecenas ut ultricies, odio tincidunt sed dolor turpis in, velit id ad non nec lorem, et pede aliquam amet euismod nunc, adipiscing erat phasellus leo erat urna sit. Sed nam interdum neque lorem ac vestibulum, quis cum elit fusce leo magna, nunc lectus ipsum euismod arcu sed quia, etiam maecenas esse eros convallis lectus nunc, erat non placerat integer a wisi. Massa blandit sit diam nec neque sagittis, aliquam sollicitudin velit eget ornare pellentesque, ut dui convallis eros ultrices eget, nec nulla lobortis lacus lacinia justo lacus, sed duis volutpat pharetra quis quisque.\t\nLorem ipsum dolor sit amet, urna neque voluptatem placerat in diam, ultrices vivamus commodo debitis purus consequat sed, dolor justo orci nec pretium sapien semper. Qui diam dignissim pede tristique dignissim, sodales dolor duis et rhoncus eros vivamus, taciti duis tincidunt amet velit mauris diam, orci vehicula semper lacus tortor vulputate. Sed ullamcorper in amet sem maecenas, dignissim et lectus hac blandit ut porttitor, ad risus donec massa vel vivamus quam, nulla et hac dui vestibulum lorem, eleifend velit ut elit faucibus suscipit. Egestas mauris aliquam vel facilisi augue, mollis leo vestibulum volutpat amet per, accumsan placerat et sed voluptatem ultricies pellentesque.";
            longText.Text = "The muffled noises you heard came gushing out once you opened the door, bringing with it the all too familiar bright sights and strong smells a traveller can meat only in a tavern. An old drinking song rules the hearts of the drinkers and you almost don't notice the woman to your right, calling for you. Her voice does not ring any bells, then again, the fuss at the inn might dim anything less loud than itself.";
            longTextScrollView.Content = longText;
            longTextScrollView.Scrolled += (object sender, ScrolledEventArgs e) => {
                System.Diagnostics.Debug.WriteLine("Scrolled!");
            };
            //longTextScrollView.BackgroundColor = Color.DarkGoldenrod;

            // Create the subtext
            Frame subtextFrame = new Frame();
            Label subtext = new Label();
            subtext.Text = "You're mission is get more information about the hijackings of late.";
            subtext.FontAttributes = FontAttributes.Italic;
            subtext.FontSize = 20;
            subtextFrame.Content = subtext;
            //subtextFrame.BackgroundColor = Color.LightSlateGray;
            subtextFrame.OutlineColor = Color.Transparent;
            subtext.TextColor = Color.LightGray;
            subtextFrame.HasShadow = false;

            // Siri read
            var speak = new Button
            {
                Text = "Read with Siri!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            speak.Clicked += async (sender, e) => {
                if (longTextScrollView.ScrollY.CompareTo(0) != 0)
                    await longTextScrollView.ScrollToAsync(0, 0, true);
                DependencyService.Get<ITextToSpeech>().Speak(longText.Text);
                await Task.Delay(8000);
                //await longTextScrollView.ScrollToAsync(0,longTextScrollView.Height, true);
                await AutoScrol(longTextScrollView, 7);
                await Task.Delay(1400);
                DependencyService.Get<ITextToSpeech>().Speak(subtext.Text);
            };

            // Content
            Content = new StackLayout
            {
                Spacing = 20,
                Children = {
                    longTextScrollView,
                    speak,
                    subtextFrame,
                    new StackLayout {
                        Children = {
                            new Button {
                                Text = "Action1 ----",
                                BackgroundColor = Color.LightGray
                            },
                            new Button {
                                Text = "Action2 ----",
                                BackgroundColor = Color.LightGray
                            },
                            new Button {
                                Text = "Action3 ----",
                                BackgroundColor = Color.LightGray
                            }
                        }
                    }
                }
            };
        }
    }
}

