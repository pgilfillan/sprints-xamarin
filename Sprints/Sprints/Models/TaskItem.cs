﻿using System;
using System.Collections.Generic;

namespace Sprints.Models
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public GoalItem goal { get; set; }

        public List<String> labels;
    }
}