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
    class AnswerViewModel : BaseViewModel
    {
        private string answer;
        public string Answer
        {
            get
            {
                return answer;
            }
            set
            {
                if(answer != value)
                {
                    answer = value;
                    OnPropertyChanged();
                }
            }
        }

        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if(id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        private Color color;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AnswerCommand { get; set; }
    }
}
