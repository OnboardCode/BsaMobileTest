using bsaMobileTest.ViewModels;
using bsaMobileTest.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace bsaMobileTest
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(UsersPage), typeof(UsersPage));
            Routing.RegisterRoute(nameof(AddUserPage), typeof(AddUserPage));
            Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
