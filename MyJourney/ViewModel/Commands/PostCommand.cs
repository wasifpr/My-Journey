﻿using MyJourney.Model;
using System;
using System.Windows.Input;

namespace MyJourney.ViewModel.Commands
{
    public class PostCommand : ICommand
    {
        NewTravelVM viewModel;

        public event EventHandler CanExecuteChanged;

        public PostCommand(NewTravelVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;

            if (post != null)
            {
                if (string.IsNullOrEmpty(post.Experience))
                    return false;

                if (post.Venue != null)
                    return true;

                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;
            viewModel.PublishPost(post);
        }
    }
}
