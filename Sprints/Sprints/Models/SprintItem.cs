using System;
using System.Collections.Generic;

namespace Sprints.Models
{
    public class SprintItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<TaskItem> Tasks { get; set; }
    }
}