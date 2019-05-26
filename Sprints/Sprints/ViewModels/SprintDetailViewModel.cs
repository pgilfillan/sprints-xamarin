using System;

using Sprints.Models;

namespace Sprints.ViewModels
{
    public class SprintDetailViewModel : BaseViewModel
    {
        public SprintItem Sprint { get; set; }
        public SprintDetailViewModel(SprintItem sprint = null)
        {
            Title = sprint?.Title;
            Sprint = sprint;
        }
    }
}
