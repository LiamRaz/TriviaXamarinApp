using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public EditPage()
        {
            InitializeComponent();
            this.BackgroundImageSource = FileImageSource.FromFile("drawable/AddQuestionBackground2");

        }

        protected override void OnBindingContextChanged()
        {
            ((EditPageViewModel)BindingContext).Pop += () => Navigation.PopAsync();
        }
    }
}