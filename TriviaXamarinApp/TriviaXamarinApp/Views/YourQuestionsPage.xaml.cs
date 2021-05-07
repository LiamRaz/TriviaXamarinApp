using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.ViewModels;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YourQuestionsPage : ContentPage
    {
        public YourQuestionsPage()
        {
            InitializeComponent();
            BindingContext = new YourQuestionsViewModel();
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {

        }

        private void SwipeItem_Invoked_1(object sender, EventArgs e)
        {

        }
    }
}