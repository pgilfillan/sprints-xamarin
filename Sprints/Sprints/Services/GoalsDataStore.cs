using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprints.Models;

namespace Sprints.Services
{
    public class GoalDataStore : IDataStore<GoalItem>
    {
        List<GoalItem> goals;

        public GoalDataStore()
        {
            goals = new List<GoalItem>();
            var mockGoals = new List<GoalItem>
            {
                new GoalItem { Id = Guid.NewGuid().ToString(), Title = "First item", Description="This is a goal description 1." },
                new GoalItem { Id = Guid.NewGuid().ToString(), Title = "Second item", Description="This is a goal description 2." },
            };

            foreach (var goal in mockGoals)
            {
                goals.Add(goal);
            }
        }

        public async Task<bool> AddItemAsync(GoalItem goal)
        {
            goals.Add(goal);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(GoalItem goal)
        {
            var oldItem = goals.Where((GoalItem arg) => arg.Id == goal.Id).FirstOrDefault();
            goals.Remove(oldItem);
            goals.Add(goal);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = goals.Where((GoalItem arg) => arg.Id == id).FirstOrDefault();
            goals.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<GoalItem> GetItemAsync(string id)
        {
            return await Task.FromResult(goals.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<GoalItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(goals);
        }
    }
}