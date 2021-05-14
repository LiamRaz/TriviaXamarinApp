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
    public partial class TriviaGamePage : ContentPage
    {
        public TriviaGamePage()
        {
            InitializeComponent();
            TriviaGameViewModel tGVM = new TriviaGameViewModel();
            BindingContext = tGVM;
            tGVM.Push += (p) => Navigation.PushAsync(p);
            this.BackgroundImageSource = FileImageSource.FromFile("drawable/NatureBackground.png");
        }
    }
}