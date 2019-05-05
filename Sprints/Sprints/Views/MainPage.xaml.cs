using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sprints.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void About_Button_Clicked(object sender, EventArgs e)
        {
            var MDPage = App.Current.MainPage as MasterDetailPage;
            MDPage.Detail.Navigation.PushAsync(new NavigationPage(new AboutPage()));
        }
    }
}