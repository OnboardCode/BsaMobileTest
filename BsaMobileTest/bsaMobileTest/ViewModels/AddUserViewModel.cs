using bsaMobileTest.Models;
using System;
using Xamarin.Forms;

namespace bsaMobileTest.ViewModels
{
    public class AddUserViewModel : BaseViewModel
    {
        #region Bindings
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
        #endregion

        #region Commands
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        #endregion
        public AddUserViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private async void OnCancel(object obj)
        {
            Clear();
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave(object obj)
        {
            try
            {
                var user = new User()
                {
                    Name = Name,
                    Username= Username,
                    Email = Email,
                    Password = Password,
                    Phone = Phone,
                    City = City,
                    Country = Country,
                    State = State,
                    Zip = Zip,
                    CityCode = CityCode,
                    CountryCode = CountryCode,
                    Birth = Birth
                };

                await App.Database.AddItemAsync(user);

                Clear();

                await Shell.Current.DisplayAlert("Success", "New user successfuly added!", "OK");

                await Shell.Current.GoToAsync("..", true);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                await Shell.Current.DisplayAlert("ERROR", "An error occurred while processing your request", "OK");
            }
        }

        private void Clear() =>  Name = Email = Username = Password = Phone = City = State = Zip = Country = CityCode = CountryCode = String.Empty;
        
    }
}