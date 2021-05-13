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
    class YourQuestionsViewModel:BaseViewModel
    {

        public YourQuestionsViewModel()
        {
            Error = string.Empty;
            Questions = new ObservableCollection<AmericanQuestion>();
            GetQuestions();
            foreach (AmericanQuestion question in ((App)App.Current).CurrentUser.Questions)
            {
                Questions.Add(question);
            }
            DeleteQuestionCommand = new Command<AmericanQuestion>(Delete);
            GoToEditCommand = new Command<AmericanQuestion>(GoToEdit);
        }

        private async void GetQuestions()
        {
            try
            {
                TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
                ((App)App.Current).CurrentUser = await proxy.LoginAsync(((App)App.Current).CurrentUser.Email, ((App)App.Current).CurrentUser.Password);
            }
            catch(Exception)
            {
                Error = "Something Went Wrong...";
            }
        }

        private void GoToEdit(AmericanQuestion question)
        {
            EditPageViewModel editViewModel = new EditPageViewModel(question);
            
            EditPage eP = new EditPage();
            eP.BindingContext = editViewModel;
            Task t = Push?.Invoke(eP);
            t.Wait();//app not responding
            Questions.Clear();
            foreach (AmericanQuestion q in ((App)App.Current).CurrentUser.Questions)
            {
                Questions.Add(q);
            }
        }

        private async void Delete(AmericanQuestion question)
        {
            
            try
            {
                TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
                bool b = await proxy.DeleteQuestion(question);
                if(!b)
                    Error = "Something Went Wrong...";
                else
                {
                    Questions.Remove(question);
                    ((App)App.Current).CurrentUser = await proxy.LoginAsync(((App)App.Current).CurrentUser.Email, ((App)App.Current).CurrentUser.Password);
                }
            }
            catch(Exception)
            {
                Error = "Something Went Wrong...";
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

        public ObservableCollection<AmericanQuestion> Questions { get; set; }

        #endregion

        #region Commands

        public ICommand DeleteQuestionCommand { get; set; }

        public ICommand GoToEditCommand { get; set; }

        #endregion

        #region Events

        public event Func<Page,Task> Push;

        #endregion

    }
}
