using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CPMobile.Views
{
    public class WebViewPage : ContentPage
    {
        public WebViewPage(string title,string url)
        {
            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = title;
            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = url,
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    webView
                }
            };
        }
    }
}
