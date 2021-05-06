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
                ButtonsGrid.Children.Add(new Button { BackgroundColor = Color.Gold, Text = "Play", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 30, WidthRequest = 150, FontAttributes = FontAttributes.Bold, FontSize = 30 },0,0);
                ButtonsGrid.Children.Add(new Button { BackgroundColor = Color.Gold, Text = "Logout", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 30, WidthRequest = 150, FontAttributes = FontAttributes.Bold, FontSize = 30 },0,1);
                ButtonsGrid.Children.Add(new Button { BackgroundColor = Color.Gold, Text = "Edit", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 30, WidthRequest = 150, FontAttributes = FontAttributes.Bold, FontSize = 30 },0,2);
            }
            else
            {
                ButtonsGrid.Children.Add(new Button { BackgroundColor = Color.Gold, Text = "Play", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 30, WidthRequest = 150, FontAttributes = FontAttributes.Bold, FontSize = 30 },0,0);
                ButtonsGrid.Children.Add(new Button { BackgroundColor = Color.Gold, Text = "Login", CornerRadius = 20, HorizontalOptions = LayoutOptions.Center, Margin = 30, WidthRequest = 150, FontAttributes = FontAttributes.Bold, FontSize = 30 },0,1);
            }

        }


    }
}