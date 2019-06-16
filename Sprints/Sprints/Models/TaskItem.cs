using System;
using System.Collections.Generic;

namespace Sprints.Models
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public GoalItem Goal { get; set; }
        public int Points { get; set; }
        public List<String> Labels { get; set; }
        public TaskItem.TaskStatus Status { get; set; }

        enum TaskStatus
        {
            Pending,
            Active,
            Completed
        }
    }


}