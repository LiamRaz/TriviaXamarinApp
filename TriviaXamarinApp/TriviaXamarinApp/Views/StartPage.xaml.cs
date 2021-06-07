using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.ViewModels;
using System.Windows.Input;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        Button PlayButton;
        Button LoginButton;
        Button LogoutButton;
        Button EditButton;
        Button SignUpButton;

        public StartPage()
        {
            InitializeComponent();
            StartPageViewModel sPVM = new StartPageViewModel();
            BindingContext = sPVM;
            sPVM.Push += (p) => Navigation.PushAsync(p);
            sPVM.PopAll += () => Navigation.PopToRootAsync();
            ((App)App.Current).Update += UpdateStartPage;

            UpdateStartPage(((App)App.Current).CurrentUser);
        }

        private void UpdateStartPage(User u)
        {
            if (u != null)
            {
                PlayButton = new Button { BackgroundColor = Color.Gold, Text = "Play", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 20, FontAttributes = FontAttributes.Bold, FontSize = 15, WidthRequest = 100, Padding = 0 };
                PlayButton.SetBinding(Button.CommandProperty, "PlayCommand");
                ButtonsGrid.Children.Add(PlayButton, 0, 0);

                LogoutButton = new Button { BackgroundColor = Color.Gold, Text = "Logout", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 20, FontAttributes = FontAttributes.Bold, FontSize = 15, WidthRequest = 100, Padding = 0 };
                LogoutButton.SetBinding(Button.CommandProperty, "LogoutCommand");
                ButtonsGrid.Children.Add(LogoutButton, 0, 1);

                EditButton = new Button { BackgroundColor = Color.Gold, Text = "Edit", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 20, FontAttributes = FontAttributes.Bold, FontSize = 15, WidthRequest = 100, Padding = 0 };
                EditButton.SetBinding(Button.CommandProperty, "EditCommand");
                ButtonsGrid.Children.Add(EditButton, 0, 2);

                LoginButton = null;
                SignUpButton = null;
            }
            else
            {
                PlayButton = new Button { BackgroundColor = Color.Gold, Text = "Play", CornerRadius = 25, HorizontalOptions = LayoutOptions.Center,  FontAttributes = FontAttributes.Bold, FontSize = 15, WidthRequest=100, Padding = 0, Margin = 20 };
                PlayButton.SetBinding(Button.CommandProperty, "PlayCommand");
                ButtonsGrid.Children.Add(PlayButton, 0, 0);

                LoginButton = new Button { BackgroundColor = Color.Gold, Text = "Login", CornerRadius = 25, HorizontalOptions = LayoutOptions.Center,FontAttributes = FontAttributes.Bold, FontSize = 15, WidthRequest = 100, Padding = 0, Margin = 20 };
                LoginButton.SetBinding(Button.CommandProperty, "LoginCommand");
                ButtonsGrid.Children.Add(LoginButton, 0, 1);

                SignUpButton = new Button { BackgroundColor = Color.Gold, Text = "Sign Up", CornerRadius = 25, HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold, FontSize = 15, WidthRequest = 100, Padding = 0, Margin = 20 };
                SignUpButton.SetBinding(Button.CommandProperty, "SignUpCommand");
                ButtonsGrid.Children.Add(SignUpButton, 0, 2);

                LogoutButton = null;
                EditButton = null;
            }
        }


    }
}