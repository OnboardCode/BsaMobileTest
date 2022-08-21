using bsaMobileTest.Models;
using bsaMobileTest.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace bsaMobileTest.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private User user;
        public ObservableCollection<User> Users { get; set; }
        public Command LoadUsersCommand { get; }
        public Command<User> UserTapped { get; }
        public Command AddUserCommand { get; }

        public User User
        {
            get => user;
            set
            {
                SetProperty(ref user, value);
                OnUserSelected(User);
            }
        }
        public UsersViewModel()
        {
            Title = "Users";
            Users = new ObservableCollection<User>();
            LoadUsersCommand = new Command(async () => await ExecuteLoadItemsCommand());
            UserTapped = new Command<User>(OnUserSelected);
            AddUserCommand = new Command(AddUser);
            ExecuteLoadItemsCommand();
        }

        private async void AddUser(object obj) => await Shell.Current.GoToAsync(nameof(AddUserPage));

        private async void OnUserSelected(User obj) 
        {
            if (obj == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(UserDetailsPage)}?{nameof(UserDetailViewModel.UserId)}={obj.Id}");
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                (await App.Database.GetItemsAsync()).ForEach(x => Users.Add(x));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            user = null;
        }        
    }
}
