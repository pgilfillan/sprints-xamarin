using System;

using Sprints.Models;

namespace Sprints.ViewModels
{
    public class GoalDetailViewModel : BaseViewModel
    {
        public Goal Goal { get; set; }
        public GoalDetailViewModel(Goal goal = null)
        {
            Title = goal?.Text;
            Goal = goal;
        }
    }
}
