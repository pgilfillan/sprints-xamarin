using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprints.Models;

namespace Sprints.Services
{
    public class TaskDataStore : IDataStore<TaskItem>
    {
        List<TaskItem> tasks;

        public TaskDataStore()
        {
            tasks = new List<TaskItem>();
            var mockTasks = new List<TaskItem>
            {
                new TaskItem { Id = Guid.NewGuid().ToString(), Title = "First item", Description="This is a task description 1." },
                new TaskItem { Id = Guid.NewGuid().ToString(), Title = "Second item", Description="This is a task description 2." },
            };

            foreach (var task in mockTasks)
            {
                tasks.Add(task);
            }
        }

        public async Task<bool> AddItemAsync(TaskItem task)
        {
            tasks.Add(task);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(TaskItem task)
        {
            var oldItem = tasks.Where((TaskItem arg) => arg.Id == task.Id).FirstOrDefault();
            tasks.Remove(oldItem);
            tasks.Add(task);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = tasks.Where((TaskItem arg) => arg.Id == id).FirstOrDefault();
            tasks.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<TaskItem> GetItemAsync(string id)
        {
            return await Task.FromResult(tasks.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<TaskItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(tasks);
        }
    }
}