using System;
using System.Collections.Generic;

namespace Sprints.Models
{
    public class SprintItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime beginDateTime { get; set; }
        public DateTime endDateTime { get; set; }


        public List<TaskItem> tasks;
    }
}