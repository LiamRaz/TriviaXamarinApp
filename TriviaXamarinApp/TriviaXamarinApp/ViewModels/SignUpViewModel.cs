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
    class SignUpViewModel:BaseViewModel
    {
        public SignUpViewModel()
        {
            SignUpCommand = new Command(SignUp);
        }

        private async void SignUp()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            try
            {


                User u = new User { Email = Email, NickName = NickName, Password = Password, Questions = new List<AmericanQuestion>() };
                bool b = await proxy.RegisterUser(u);
                if (b)
                    Push?.Invoke(new LoginPage());
                else
                    Error = "Something Went Wrong...";
            }
            catch(Exception)
            {
                Error = "Something Went Wrong...";
            }
        }

        #region Properties

        private string email;

        public string Email
        {
            get => email;
            set
            {
                if (value != email)
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
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        private string nickName;

        public string NickName
        {
            get => nickName;
            set
            {
                if (value != nickName)
                {
                    nickName = value;
                    OnPropertyChanged();//maybe need nameof
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
        public ICommand SignUpCommand { get; set; }

        #endregion

        #region Events

        public event Action<Page> Push;

        #endregion

    }
}
