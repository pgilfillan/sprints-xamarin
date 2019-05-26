using System;

namespace Sprints.Models
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public GoalItem goal { get; set; }

    }
}