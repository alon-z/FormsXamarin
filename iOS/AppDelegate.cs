using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace FormsXamarin.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            // Get possible shortcut item
            if (options != null)
            {
                LaunchedShortcutItem = options[UIApplication.LaunchOptionsShortcutItemKey] as UIApplicationShortcutItem;
            }

            // Add dynamic shortcut items
            var shortcut_continue = new UIMutableApplicationShortcutItem(ShortcutIdentifier.Continue, "Continue Book")
            {
                LocalizedSubtitle = "Continue to read you'r book",
                Icon = UIApplicationShortcutIcon.FromType(UIApplicationShortcutIconType.Bookmark)
            };

            var shortcut_search = new UIMutableApplicationShortcutItem(ShortcutIdentifier.Search, "Search store")
            {
                LocalizedSubtitle = "Search for a new book",
                Icon = UIApplicationShortcutIcon.FromType(UIApplicationShortcutIconType.Search)
            };

            // Update the application providing the initial 'dynamic' shortcut items.
            app.ShortcutItems = new UIApplicationShortcutItem[] { shortcut_continue, shortcut_search };

            return base.FinishedLaunching(app, options);
        }

        public UIApplicationShortcutItem LaunchedShortcutItem { get; set; }

        public bool HandleShortcutItem(UIApplicationShortcutItem shortcutItem)
        {
            var handled = false;

            // Anything to process?
            if (shortcutItem == null) return false;

            // Take action based on the shortcut type
            switch (shortcutItem.Type)
            {
                case ShortcutIdentifier.Continue:
                    Console.WriteLine("Continue shortcut selected");
                    handled = true;
                    break;
                case ShortcutIdentifier.Search:
                    Console.WriteLine("Search shortcut selected");
                    handled = true;
                    break;
            }

            // Return results
            return handled;
        }

        /*public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            var shouldPerformAdditionalDelegateHandling = true;

            // Get possible shortcut item
            if (launchOptions != null)
            {
                LaunchedShortcutItem = launchOptions[UIApplication.LaunchOptionsShortcutItemKey] as UIApplicationShortcutItem;
                shouldPerformAdditionalDelegateHandling = (LaunchedShortcutItem == null);
            }

            return shouldPerformAdditionalDelegateHandling || base.FinishedLaunching(application, launchOptions);
        }*/

        public override void OnActivated(UIApplication application)
        {
            // Handle any shortcut item being selected
            HandleShortcutItem(LaunchedShortcutItem);

            // Clear shortcut after it's been handled
            LaunchedShortcutItem = null;
        }

        public override void PerformActionForShortcutItem(UIApplication application, UIApplicationShortcutItem shortcutItem, UIOperationHandler completionHandler)
        {
            // Perform action
            completionHandler(HandleShortcutItem(shortcutItem));
        }
    }
}
