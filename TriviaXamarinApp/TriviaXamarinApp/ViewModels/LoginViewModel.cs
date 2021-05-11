using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;
using System.Threading.Tasks;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp.ViewModels
{
    class LoginViewModel:BaseViewModel
    {
        
        public LoginViewModel()
        {
            Email = string.Empty;
            Password = string.Empty;
            Error = string.Empty;
            LoginCommand = new Command(Login);
            SignUpCommand = new Command(SignUp);
        }

        private void SignUp()
        {
            Push?.Invoke(new SignUpPage());
        }

        private async void Login()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            try
            {
                User u = await proxy.LoginAsync(Email, Password);
                if (u != null)
                {
                    ((App)App.Current).CurrentUser = u;
                    Push?.Invoke(new StartPage());
                }
            }
            catch(Exception)
            {
                Error = "Something Went Wrong...";
            }
           
            //move to next page
        }

        #region Properties
        private string email;

        public string Email
        {
            get => email;
            set
            {
                if(value != email)
                {
                    email = value;
                    OnPropertyChanged();//maybe need nameof
                }
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                if(value!= password)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }


        private string error;

        public string Error
        {
            get => error;
            set
            {
                if (value != error)
                {
                    error = value;
                    OnPropertyChanged();//maybe need nameof
                }
            }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        public ICommand SignUpCommand { get; set; }
        #endregion

        #region Events

        public event Action<Page> Push;

        #endregion
    }
}
