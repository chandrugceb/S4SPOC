using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SchrackPOC.Views
{
    public partial class BookIndexPage : ContentPage
    {
        void Handle_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        public BookIndexPage()
        {
            InitializeComponent();
            Title = "Book Index";
        }

        void Handle_Tapped_1(object sender, System.EventArgs e)
        {
            stkSubChapter.IsVisible = stkSubChapter.IsVisible != true;
            imgUp.IsVisible = imgUp.IsVisible != true;
            imgDown.IsVisible = imgDown.IsVisible != true;
        }
    }
}
