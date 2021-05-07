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
    class YourQuestionsViewModel:BaseViewModel
    {

        public YourQuestionsViewModel()
        {
            DeleteQuestion = new Command(Delete);
            GoToEditCommand = new Command(GoToEdit);
        }

        private void GoToEdit(object obj)
        {
            throw new NotImplementedException();
        }

        private async void Delete()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            bool b = await proxy.DeleteQuestion(ChosenQuestion);

        }

        #region Properties

        private AmericanQuestion chosenQuestion;

        public AmericanQuestion ChosenQuestion
        {
            get => chosenQuestion;
            set
            {
                if(value != chosenQuestion)
                {
                    chosenQuestion = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands

        public ICommand DeleteQuestion { get; set; }

        public ICommand GoToEditCommand { get; set; }

        #endregion

        #region Events

        public event Action<Page> Push;

        #endregion

    }
}
