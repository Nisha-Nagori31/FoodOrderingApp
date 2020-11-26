using FoodOrderingApp.Services;
using FoodOrderingApp.Views;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderingApp.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {

        #region Properties and Commands
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private bool _isbusy;
        public bool IsBusy
        {
            get { return _isbusy; }
            set { _isbusy = value; }
        }

        private bool _result;
        public bool Result
        {
            get { return _result; }
            set { _result = value; }
        }

        //command property
        public Command LoginCommand { get; set; }
       public Command RegisterCommand { get; set; }

        #endregion


        #region Constructor
        public LoginViewModel()
        {
            //command initialization
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }
        #endregion
        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var userservice = new UserService();
                Result=await userservice.LoginUser(Username, Password);
                if(Result)
                {
                    //
                    Preferences.Set("Username", Username);
                    //
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsViewPage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "cancel");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var userservice = new UserService();
                Result=await userservice.RegisterUser(Username, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registerd", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "User Already Registerd with this credentials", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "cancel");
            }
            finally
            {
                IsBusy = false;
            }
        }
       
    }
}
