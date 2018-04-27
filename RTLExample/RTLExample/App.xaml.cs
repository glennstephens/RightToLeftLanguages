using Plugin.Multilingual;
using RTLExample.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RTLExample
{
	public partial class App : Application
	{
        public static NavigationPage NavPage = null;

        public App()
        {
            InitializeComponent();

            // Set up the initial culture (we're starting this one in English)
            //CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
            //AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;

            // To set it up for the device's culture use
            CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.DeviceCultureInfo;
            AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;

            NavPage = new NavigationPage(new SelectLanguagePage());
            MainPage = NavPage;
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
