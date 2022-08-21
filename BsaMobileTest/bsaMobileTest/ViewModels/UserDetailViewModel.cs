using System;
using Xamarin.Forms;
namespace bsaMobileTest.ViewModels
{
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public class UserDetailViewModel : BaseViewModel
    {
        private int id;
        private string name;
        private string username;
        private string email;
        private string password;
        private string phone;
        private string city;
        private string state;
        private string zip;
        private string country;
        private string countrycode;
        private string cityCode;
        private DateTime birth;
        private bool enabled;

        public int Id { get; set; }
        public int UserId { get => id; set { SetProperty(ref id, value); LoadUser(value); } }
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Email { get => email; set => SetProperty(ref email, value); }
        public string Username { get => username; set => SetProperty(ref username, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }
        public string Phone { get => phone; set => SetProperty(ref phone, value); }
        public string City { get => city; set => SetProperty(ref city, value); }
        public string State { get => state; set => SetProperty(ref state, value); }
        public string Zip { get => zip; set => SetProperty(ref zip, value); }
        public string Country { get => country; set => SetProperty(ref country, value); }
        public string CityCode { get => cityCode; set => SetProperty(ref cityCode, value); }
        public string CountryCode { get => countrycode; set => SetProperty(ref countrycode, value); }
        public DateTime Birth { get => birth; set => SetProperty(ref birth, value); }
        public bool Enabled { get => enabled; set => SetProperty(ref enabled, value); }

        public Command EditUserCommand { get; }
        public Command DelUserCommand { get; }

        public Command SaveUserCommand { get; }

        public UserDetailViewModel()
        {
            Enabled = false;
            EditUserCommand = new Command(() => { Enabled = !Enabled; });
            DelUserCommand = new Command(ExecuteDelUserCommand);
            SaveUserCommand = new Command(ExecuteSaveUserCommand);
        }

        private async void ExecuteSaveUserCommand(object obj)
        {
            try
            {
                var user = new Models.User();
                user.Id = this.UserId;
                user.Email = this.email;
                user.Password = this.password;
                user.Phone = this.Phone;
                user.Birth = this.Birth;
                user.City = this.City;
                user.CityCode = this.CityCode;
                user.Country = this.Country;
                user.CountryCode = this.CountryCode;
                user.Username = this.Username;
                user.Name = this.Name;
                user.State = this.State;
                user.Zip = this.Zip;

                await App.Database.UpdateItemAsync(user);

                await Shell.Current.CurrentPage.DisplayAlert("Info", "User successfuly updated!", "OK");

                await Shell.Current.GoToAsync("..");

            }
            catch (Exception e)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Error", "There was an error at saving user. Message:\n" + e.Message, "OK");
            }
        }

        private async void ExecuteDelUserCommand(object obj)
        {
            try
            {
                if (!(await Shell.Current.CurrentPage.DisplayAlert("Alert", "Are you sure to delete the user?", "OK", "Cancel")))
                    return;

                await App.Database.DeleteItemAsync(this.UserId);
                await Shell.Current.CurrentPage.DisplayAlert("Alert", "User deleted!", "OK");
            }
            catch (Exception e)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Error", "There was an error at delete user. Message:\n" + e.Message, "OK");
            }
        }

        private async void LoadUser(int value)
        {
            try
            {
                Models.User user = await App.Database.GetItemAsync(value);

                this.UserId = user.Id;
                this.email = user.Email;
                this.password = user.Password;
                this.Phone = user.Phone;
                this.Birth = user.Birth;
                this.City = user.City;
                this.CityCode = user.CityCode;
                this.Country = user.Country;
                this.CountryCode = user.CountryCode;
                this.Username = user.Username;
                this.Name = user.Name;
                this.State = user.State;
                this.Zip = user.Zip;
            }
            catch (Exception e)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Error", "There was an error at load user. Message:\n" + e.Message, "OK");
            }
        }
    }
}
