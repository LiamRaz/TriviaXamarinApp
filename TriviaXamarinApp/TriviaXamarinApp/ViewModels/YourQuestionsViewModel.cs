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
            ChosenQuestion = null;
            Error = string.Empty;
            DeleteQuestion = new Command<AmericanQuestion>(Delete);
            GoToEditCommand = new Command<AmericanQuestion>(GoToEdit);
        }

        private void GoToEdit(AmericanQuestion question)
        {
            EditPageViewModel editViewModel = new EditPageViewModel();
            editViewModel.QTextBefore = question.QText;
            editViewModel.QTextAfter = question.QText;
            editViewModel.CorrectAnswerBefore = question.CorrectAnswer;
            editViewModel.CorrectAnswerAfter = question.CorrectAnswer;
            for (int i = 0; i < editViewModel.OtherAnswersBefore.Length; i++)
            {
                editViewModel.OtherAnswersBefore[i] = question.OtherAnswers[i];
                editViewModel.OtherAnswersAfter[i] = question.OtherAnswers[i];
            }
            EditPage eP = new EditPage();
            eP.BindingContext = editViewModel;
            Push?.Invoke(new NavigationPage(eP));
        }

        private async void Delete(AmericanQuestion question)
        {
            ChosenQuestion = question;
            try
            {
                TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
                bool b = await proxy.DeleteQuestion(ChosenQuestion);
                if(!b)
                    Error = "Something Went Wrong...";
            }
            catch(Exception)
            {
                Error = "Something Went Wrong...";
            }
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

        private string error;

        public string Error
        {
            get => error;
            set
            {
                if (value != error)
                {
                    error = value;
                    OnPropertyChanged();//maybe need nameof
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
