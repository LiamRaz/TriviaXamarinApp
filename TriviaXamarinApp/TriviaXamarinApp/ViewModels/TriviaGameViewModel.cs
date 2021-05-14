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
    class TriviaGameViewModel:BaseViewModel
    {

        public TriviaGameViewModel()
        {
            this.EnableAnswer = true;
            this.EnableAdd = false;
            this.EnableNext = false;
            this.AddOpacity = 0.5;
            this.NumAdd = 0;
            this.NumCorrect = 0;
            this.NumWrong = 0;
            this.Error = string.Empty;
            AllAnswers = new ObservableCollection<string>();
            for (int i = 0; i < NUM_ANSWERS; i++)
            {
                AllAnswers.Add(string.Empty);
            }
            GetQ();

            this.AnswersColor = new ObservableCollection<Color>();
            this.AnswersColor.Add(Color.White);
            this.AnswersColor.Add(Color.White);
            this.AnswersColor.Add(Color.White);
            this.AnswersColor.Add(Color.White);

            AddQCommand = new Command(GoToAddQ);
            NextQCommand = new Command(NextQ);
            IsCorrectCommand = new Command<string>(IsCorrect);
        }

        
        private void IsCorrect(string i)
        {
            int index = int.Parse(i);
            if (EnableAnswer)
            {
                if (AllAnswers[index] == CorrectAnswer)
                {
                    NumCorrect++;
                    if (NumCorrect % 3 == 0)
                        NumAdd++;

                    if (NumAdd > 0)
                        this.EnableAdd = true;
                    this.AnswersColor[index] = Color.Lime;
                }
                else
                {
                    NumWrong++;
                    this.AnswersColor[index] = Color.Red;
                    this.AnswersColor[indexOfCorrect] = Color.Lime;
                }

                if (NumAdd > 0)
                    this.AddOpacity = 1;

                this.EnableAnswer = false;
                this.EnableNext = true;
            }
            
        }

        private void NextQ()
        {
            this.EnableNext = false;
            for (int i = 0; i < NUM_ANSWERS; i++)
            {
                AllAnswers[i] = string.Empty;
                AnswersColor[i] = Color.White;
                
            }
            GetQ();
            this.EnableAnswer = true;

        }

        private void GoToAddQ()
        {
            if(NumAdd >0)
            {
                Push?.Invoke(new AddQuestionPage());
                NumAdd--;
                AddOpacity = 0.5;
                
                if (NumAdd <= 0)
                    this.EnableAdd = false;
            }
        }

        private async void GetQ()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            try
            {
                AmericanQuestion q = await proxy.GetRandomQuestion();
                if (q != null)
                {
                    this.CorrectAnswer = q.CorrectAnswer;
                    this.QText = q.QText;
                    ShuffleAnswers(q);
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

        private void ShuffleAnswers(AmericanQuestion q)
        {
            Random rnd = new Random();
            int counter = 0;
            this.indexOfCorrect = rnd.Next(0, NUM_ANSWERS);
            AllAnswers[indexOfCorrect] = this.CorrectAnswer;
            for (int i = 0; i < NUM_ANSWERS; i++)
            {
                if(i != indexOfCorrect)
                {
                    AllAnswers[i] = q.OtherAnswers[counter];
                    counter++;
                }
            }
        }

        #region Properties

        private double addOpacity;

        public double AddOpacity
        {
            get => addOpacity;
            set
            {
                if (value != addOpacity)
                {
                    addOpacity = value;
                    OnPropertyChanged();
                }
            }
        }

        private int indexOfCorrect;

        private bool enableAnswer;

        public bool EnableAnswer
        {
            get => enableAnswer;
            set
            {
                if(value != enableAnswer)
                {
                    enableAnswer = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool enableAdd;

        public bool EnableAdd
        {
            get => enableAdd;
            set
            {
                if (value != enableAdd)
                {
                    enableAdd = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool enableNext;

        public bool EnableNext
        {
            get => enableNext;
            set
            {
                if (value != enableNext)
                {
                    enableNext = value;
                    OnPropertyChanged();
                }
            }
        }

        private const int NUM_ANSWERS = 4;

        public ObservableCollection<Color> AnswersColor { get; set; }


        private int numCorrect;

        public int NumCorrect
        {
            get => numCorrect;
            set
            {
                if(value!=numCorrect)
                {
                    numCorrect = value;
                    OnPropertyChanged();
                }
            }
        }


        private int numWrong;

        public int NumWrong
        {
            get => numWrong;
            set
            {
                if (value != numWrong)
                {
                    numWrong = value;
                    OnPropertyChanged();
                }
            }
        }

        private int numAdd;

        public int NumAdd
        {
            get => numAdd;
            set
            {
                if (value != numAdd)
                {
                    numAdd = value;
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
                if(value!=error)
                {
                    error = value;
                    OnPropertyChanged();
                }
            }
        }

        private string qText;

        public string QText
        {
            get => qText;
            set
            {
                if (value != qText)
                {
                    qText = value;
                    OnPropertyChanged();
                }
            }
        }

        private string correctAnswer;

        public string CorrectAnswer
        {
            get => correctAnswer;
            set
            {
                if (value != correctAnswer)
                {
                    correctAnswer = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> AllAnswers { get; set; }


        #endregion

        #region Commands

        public ICommand AddQCommand { get; set; }

        public ICommand NextQCommand { get; set; }

        public ICommand IsCorrectCommand { get; set; }

        #endregion

        #region Events

        public event Action<Page> Push;

        #endregion

    }
}
