using Plugin.Multilingual;
using RTLExample.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTLExample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectLanguagePage : ContentPage
	{
		public SelectLanguagePage ()
		{
			InitializeComponent ();
		}

        void ShowLanguage(string language, bool showRightToLeft)
        {
            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo(language);
            AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;

            var newPage = new RTLExamplePage();
            //newPage.FlowDirection = showRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            NavigationPage.SetBackButtonTitle(App.NavPage, AppResources.BackText);

            Navigation.PushAsync(newPage);
        }

        void ShowEnglish(object sender, System.EventArgs e)
        {
            ShowLanguage("en", false);
        }

        void ShowArabic(object sender, System.EventArgs e)
        {
            ShowLanguage("ar", true);
        }
    }
}