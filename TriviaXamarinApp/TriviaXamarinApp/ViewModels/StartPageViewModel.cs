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
            PlayCommand = new Command(Play);
            LoginCommand = new Command(Login);
            LogoutCommand = new Command(LogOut);
            EditCommand = new Command(Edit);
        }

        private async void Edit()
        {
            //Push?.Invoke(new NavigationPage());
        }

        private void LogOut()
        {
            ((App)App.Current).CurrentUser = null;
        }

        private void Login()
        {
            Push?.Invoke(new NavigationPage(new LoginPage()));
        }

        private void Play()
        {
            //if(((App)App.Current).CurrentUser != null)
                  //Push?.Invoke(new NavigationPage());
            //else
                  //Push?.Invoke(new NavigationPage());

        }

        #region Properties

        #endregion

        #region Commands

        public ICommand PlayCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand EditCommand { get; set; }

        #endregion

        #region Events

        public event Action<Page> Push;

        #endregion
    }
}
