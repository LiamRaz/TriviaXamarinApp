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
    class WriteQuestionViewModel:BaseViewModel
    {

        public WriteQuestionViewModel()
        {
            this.CorrectAnswer = string.Empty;
            this.QText = string.Empty;
            this.WrongAnswers = new string[NUM_WRONG];
            for (int i = 0; i < this.WrongAnswers.Length; i++)
            {
                this.WrongAnswers[i] = string.Empty;
            }

            SubmitQuestionCommand = new Command(SubmitQuestion);
        }

        private async void SubmitQuestion()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            try
            {
                AmericanQuestion question = new AmericanQuestion
                {
                    CorrectAnswer = this.CorrectAnswer,
                    QText = this.QText,
                    CreatorNickName = ((App)App.Current).CurrentUser.NickName,
                    OtherAnswers = new string[NUM_WRONG],
                };
                for (int i = 0; i < this.WrongAnswers.Length; i++)
                {
                    question.OtherAnswers[i] = this.WrongAnswers[i];
                }

                bool b = await proxy.PostNewQuestion(question);
                if(b)
                {
                    Error = "question added successfully";
                }
                else
                {
                    Error = "Something Went Wrong...";
                }

                
            }
            catch(Exception)
            {
                Error = "Something Went Wrong...";
            }
        }


        #region Properties

        private const int NUM_WRONG = 3;

        private string qText;

        public string QText
        {
            get => this.qText;
            set
            {
                if(value != qText)
                {
                    qText = value;
                    OnPropertyChanged();
                }
            }
        }


        private string correctAnswer;

        public string CorrectAnswer
        {
            get => this.correctAnswer;
            set
            {
                if (value != correctAnswer)
                {
                    correctAnswer = value;
                    OnPropertyChanged();
                }
            }
        }


        private string[] wrongAnswers;

        public string[] WrongAnswers
        {
            get => this.wrongAnswers;
            set
            {
                if (value != wrongAnswers)
                {
                    wrongAnswers = value;
                    OnPropertyChanged();
                }
            }
        }


        private string error;

        public string Error
        {
            get => this.error;
            set
            {
                if (value != error)
                {
                    error = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands

        public ICommand SubmitQuestionCommand { get; set; }

        #endregion

        #region Events

        public event Action<Page> Push;

        #endregion

    }
}
