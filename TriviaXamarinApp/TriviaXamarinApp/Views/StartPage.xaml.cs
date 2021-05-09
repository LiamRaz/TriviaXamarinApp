using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.ViewModels;
using System.Windows.Input;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            BindingContext = new StartPageViewModel();



            if (((App)App.Current).CurrentUser != null)
            {
                Button b = new Button { BackgroundColor = Color.Gold, Text = "Play", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 10, WidthRequest = 100, FontAttributes = FontAttributes.Bold, FontSize = 15 };
                b.SetBinding(Button.CommandProperty, "PlayCommand");
                ButtonsGrid.Children.Add(b,0,0);
                
                Button b2 = new Button { BackgroundColor = Color.Gold, Text = "Logout", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 10, WidthRequest = 100, FontAttributes = FontAttributes.Bold, FontSize = 15 };
                b2.SetBinding(Button.CommandProperty, "LogoutCommand");
                ButtonsGrid.Children.Add(b2, 0, 1) ;

                Button b3 = new Button { BackgroundColor = Color.Gold, Text = "Edit", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 10, WidthRequest = 100, FontAttributes = FontAttributes.Bold, FontSize = 15 };
                b3.SetBinding(Button.CommandProperty, "EditCommand");
                ButtonsGrid.Children.Add(b3,0,2);
            }
            else
            {
                Button b = new Button { BackgroundColor = Color.Gold, Text = "Play", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, WidthRequest = 100, FontAttributes = FontAttributes.Bold, FontSize = 15 };
                b.SetBinding(Button.CommandProperty, "PlayCommand");
                ButtonsGrid.Children.Add(b,0,0);

                Button b1 = new Button { BackgroundColor = Color.Gold, Text = "Login", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, WidthRequest = 100, FontAttributes = FontAttributes.Bold, FontSize = 15 };
                b1.SetBinding(Button.CommandProperty, "LoginCommand");
                ButtonsGrid.Children.Add(b1,0,1);
            }

        }


    }
}