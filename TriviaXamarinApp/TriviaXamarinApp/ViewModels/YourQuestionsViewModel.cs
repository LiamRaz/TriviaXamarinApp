﻿using System;
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
            //GetQuestions();
            foreach (AmericanQuestion question in ((App)App.Current).CurrentUser.Questions)
            {
                Questions.Add(question);
            }
            DeleteQuestionCommand = new Command<AmericanQuestion>(Delete);
            GoToEditCommand = new Command<AmericanQuestion>(GoToEdit);
            RefreshCommand = new Command(Refresh);
        }

        public void Refresh()
        {
           GetQuestions();
           RefreshView.IsRefreshing = false;
        }

        private async void GetQuestions()
        {
            try
            {
                TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
                ((App)App.Current).CurrentUser = await proxy.LoginAsync(((App)App.Current).CurrentUser.Email, ((App)App.Current).CurrentUser.Password);
                if(((App)App.Current).CurrentUser == null)
                    Error = "Something Went Wrong...";
                else
                {
                    Questions.Clear();
                    foreach (AmericanQuestion q in ((App)App.Current).CurrentUser.Questions)
                    {
                        Questions.Add(q);
                    }
                }
            }
            catch(Exception)
            {
                Error = "Something Went Wrong...";
            }
        }

        private void GoToEdit(AmericanQuestion question)
        {
            
            
            EditPage eP = new EditPage(question);
            
            Push?.Invoke(eP);
            //t.Wait();//app not responding
            //Questions.Clear();
            //foreach (AmericanQuestion q in ((App)App.Current).CurrentUser.Questions)
            //{
            //    Questions.Add(q);
            //}
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

        public RefreshView RefreshView { get; set; }

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

        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }

        public ICommand GoToEditCommand { get; set; }

        #endregion

        #region Events

        public event Action<Page> Push;

        #endregion

    }
}
