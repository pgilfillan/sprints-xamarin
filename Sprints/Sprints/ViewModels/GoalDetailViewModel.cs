using System;

using Sprints.Models;

namespace Sprints.ViewModels
{
    public class GoalDetailViewModel : BaseViewModel
    {
        public GoalItem Goal { get; set; }
        public GoalDetailViewModel(GoalItem goal = null)
        {
            Title = goal?.Title;
            Goal = goal;
        }
    }
}
