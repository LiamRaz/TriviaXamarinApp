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
    class EditPageViewModel:BaseViewModel
    {

        public EditPageViewModel()
        {
            Error = string.Empty;
            QTextBefore = string.Empty;
            QTextAfter = string.Empty;
            CorrectAnswerBefore = string.Empty;
            CorrectAnswerAfter = string.Empty;
            OtherAnswersAfter = new string[OTHER_ANSWERS_NUM];
            OtherAnswersBefore = new string[OTHER_ANSWERS_NUM];
            for (int i = 0; i < OTHER_ANSWERS_NUM ; i++)
            {
                OtherAnswersAfter[i] = string.Empty;
                OtherAnswersBefore[i] = string.Empty;
            }

            SubmitQuestionCommand = new Command(SubmitQuestion);
        }

        private async void SubmitQuestion()
        {
            AmericanQuestion toBeDeleted = new AmericanQuestion
            {
                QText = this.QTextBefore,
                CorrectAnswer = this.CorrectAnswerBefore,
                CreatorNickName = ((App)App.Current).CurrentUser.NickName,
                OtherAnswers = otherAnswersBefore
            };

            try
            {
                TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
                if(!await proxy.DeleteQuestion(toBeDeleted))
                {
                    Error = "Something Went Wrong...";
                }

            }
            catch(Exception)
            {
                Error = "Something Went Wrong...";
            }

            if(!string.IsNullOrEmpty(Error))
            {
                AmericanQuestion newQuestion = new AmericanQuestion
                {
                    QText = this.QTextAfter,
                    CorrectAnswer = this.CorrectAnswerAfter,
                    CreatorNickName = ((App)App.Current).CurrentUser.NickName,
                    OtherAnswers = otherAnswersAfter
                };

                try
                {
                    TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
                    if (!await proxy.PostNewQuestion(newQuestion))
                    {
                        Error = "Something Went Wrong...";
                    }

                }
                catch (Exception)
                {
                    Error = "Something Went Wrong...";
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

        private string qTextBefore;

        public string QTextBefore
        {
            get => qTextBefore;
            set
            {
                if(value != qTextBefore)
                {
                    qTextBefore = value;
                    OnPropertyChanged();
                }
            }
        }

        private string correctAnswerBefore;

        public string CorrectAnswerBefore
        {
            get => correctAnswerBefore;
            set
            {
                if (value != correctAnswerBefore)
                {
                    correctAnswerBefore = value;
                    OnPropertyChanged();
                }
            }
        }


        private string[] otherAnswersBefore;

        public string[] OtherAnswersBefore
        {
            get => otherAnswersBefore;
            set
            {
                if (value != otherAnswersBefore)
                {
                    otherAnswersBefore = value;
                    OnPropertyChanged();
                }
            }
        }


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


        private string[] otherAnswersAfter;

        public string[] OtherAnswersAfter
        {
            get => otherAnswersAfter;
            set
            {
                if (value != otherAnswersAfter)
                {
                    otherAnswersAfter = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands

        public ICommand SubmitQuestionCommand { get; set; }

        #endregion

        #region Events

        #endregion


    }
}
