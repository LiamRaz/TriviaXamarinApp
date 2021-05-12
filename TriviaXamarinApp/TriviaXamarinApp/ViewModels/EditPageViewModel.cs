using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;
using System.Threading.Tasks;
using TriviaXamarinApp.Views;
using System.Collections.ObjectModel;

namespace TriviaXamarinApp.ViewModels
{
    class EditPageViewModel:BaseViewModel
    {

        public EditPageViewModel(AmericanQuestion question)
        {
            questionBefore = question;
            QTextAfter = question.QText;
            CorrectAnswerAfter = question.CorrectAnswer;
            OtherAnswersAfter = new ObservableCollection<string>();
            foreach (string wrongAnswer in question.OtherAnswers)
            {
                OtherAnswersAfter.Add(wrongAnswer);
            }

            SubmitQuestionCommand = new Command(SubmitQuestion);
        }

        private async void SubmitQuestion()
        {
            try
            {
                TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
                if(!await proxy.DeleteQuestion(questionBefore))
                {
                    Error = "Something Went Wrong...";
                }

            }
            catch(Exception)
            {
                Error = "Something Went Wrong...";
            }

            if(string.IsNullOrEmpty(Error))
            {
                AmericanQuestion newQuestion = new AmericanQuestion
                {
                    QText = this.QTextAfter,
                    CorrectAnswer = this.CorrectAnswerAfter,
                    CreatorNickName = ((App)App.Current).CurrentUser.NickName,
                    OtherAnswers = new string[]
                    {
                        OtherAnswersAfter[0],
                        OtherAnswersAfter[1],
                        OtherAnswersAfter[2]
                    }
                };

                try
                {
                    TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
                    if (!await proxy.PostNewQuestion(newQuestion))
                    {
                        Error = "Something Went Wrong...";
                    }

                    ((App)App.Current).CurrentUser = await proxy.LoginAsync(((App)App.Current).CurrentUser.Email, ((App)App.Current).CurrentUser.Password);
                    Pop?.Invoke();
                }
                catch (Exception)
                {
                    Error = "Something Went Wrong..";
                }
            }

            
        }

        #region Properties

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


        private const int OTHER_ANSWERS_NUM = 3;

        private AmericanQuestion questionBefore;


        private string qTextAfter;

        public string QTextAfter
        {
            get => qTextAfter;
            set
            {
                if (value != qTextAfter)
                {
                    qTextAfter = value;
                    OnPropertyChanged();
                }
            }
        }

        private string correctAnswerAfter;

        public string CorrectAnswerAfter
        {
            get => correctAnswerAfter;
            set
            {
                if (value != correctAnswerAfter)
                {
                    correctAnswerAfter = value;
                    OnPropertyChanged();
                }
            }
        }


        public ObservableCollection<string> OtherAnswersAfter { get; set; }

        #endregion

        #region Commands

        public ICommand SubmitQuestionCommand { get; set; }

        #endregion

        #region Events

        public event Action Pop;

        #endregion


    }
}
