using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprints.Models;

namespace Sprints.Services
{
    public class GoalDataStore : IDataStore<Goal>
    {
        List<Goal> goals;

        public GoalDataStore()
        {
            goals = new List<Goal>();
            var mockGoals = new List<Goal>
            {
                new Goal { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Goal { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
            };

            foreach (var goal in mockGoals)
            {
                goals.Add(goal);
            }
        }

        public async Task<bool> AddItemAsync(Goal goal)
        {
            goals.Add(goal);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Goal goal)
        {
            var oldItem = goals.Where((Goal arg) => arg.Id == goal.Id).FirstOrDefault();
            goals.Remove(oldItem);
            goals.Add(goal);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = goals.Where((Goal arg) => arg.Id == id).FirstOrDefault();
            goals.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Goal> GetItemAsync(string id)
        {
            return await Task.FromResult(goals.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Goal>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(goals);
        }
    }
}