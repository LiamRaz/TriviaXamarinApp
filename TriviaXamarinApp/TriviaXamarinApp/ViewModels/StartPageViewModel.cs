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
    class StartPageViewModel:BaseViewModel
    {
        public StartPageViewModel()
        {
            SignUpCommand = new Command(SignUp);
            PlayCommand = new Command(Play);
            LoginCommand = new Command(Login);
            LogoutCommand = new Command(LogOut);
            EditCommand = new Command(Edit);
        }

        private void SignUp()
        {
            Push?.Invoke(new SignUpPage());
        }

        private void Edit()
        {
            Push?.Invoke(new YourQuestionsPage());
        }

        private void LogOut()
        {
            ((App)App.Current).CurrentUser = null;
        }

        private void Login()
        {
            Push?.Invoke(new LoginPage());
        }

        private void Play()
        {
            if (((App)App.Current).CurrentUser != null)
            {
                Push?.Invoke(new TriviaGamePage());
            }
            else
                Push?.Invoke(new LoginPage());

        }

        #region Properties

        #endregion

        #region Commands

        public ICommand PlayCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        #endregion

        #region Events

        public event Action<Page> Push;

        #endregion
    }
}
