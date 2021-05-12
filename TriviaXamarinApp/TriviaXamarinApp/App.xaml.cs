using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;
using System.Threading.Tasks;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp
{
    public partial class App : Application
    {
        public event Action<User> Update;

        private User currentUser;
        public User CurrentUser 
        {
            get => currentUser;
            set
            {
                if(value != currentUser)
                {
                    currentUser = value;
                    Update?.Invoke(currentUser);
                }
            }
        }
        public App()
        {
            InitializeComponent();

            CurrentUser = null;
            MainPage = new NavigationPage(new StartPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
