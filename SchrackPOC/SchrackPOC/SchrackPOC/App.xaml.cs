using System;
using SchrackPOC.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SchrackPOC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new NavigationPage(new BookIndexPage());
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromRgb(0,88,157);
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            //MainPage = new NavigationPage( new BookIndexPage()); 

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
