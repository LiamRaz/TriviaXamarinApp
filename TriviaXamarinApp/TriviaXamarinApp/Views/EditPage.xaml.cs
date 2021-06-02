using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModels;
using TriviaXamarinApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public EditPage(AmericanQuestion q)
        {
            InitializeComponent();
            EditPageViewModel viewModel = new EditPageViewModel(q);
            viewModel.Pop += () => Navigation.PopAsync();
            BindingContext = viewModel;
            this.BackgroundImageSource = FileImageSource.FromFile("drawable/AddQuestionBackground2");

        }

        //protected override void OnBindingContextChanged()
        //{
        //    ((EditPageViewModel)BindingContext).Pop += () => Navigation.PopAsync();
        //}
    }
}