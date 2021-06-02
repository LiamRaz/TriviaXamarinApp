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
    public partial class AddQuestionPage : ContentPage
    {
        public AddQuestionPage()
        {
            InitializeComponent();
            BindingContext = new AddQuestionViewModel();
            this.BackgroundImageSource = FileImageSource.FromFile("drawable/AddQuestionBackground2");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            AddQuestionViewModel viewModel = ((AddQuestionViewModel)BindingContext);
            if (string.IsNullOrEmpty(viewModel.QuestionText) || string.IsNullOrEmpty(viewModel.CorrectAnswer) || string.IsNullOrEmpty(viewModel.WrongAnswers[0]) || string.IsNullOrEmpty(viewModel.WrongAnswers[1]) || string.IsNullOrEmpty(viewModel.WrongAnswers[2]))
            {
                await DisplayAlert("Alert", "Oops... Please fill all empty fields:)", "Ok");
            }
        }
    }
}