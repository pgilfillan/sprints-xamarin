using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprints.Models;

namespace Sprints.Services
{
    public class SprintDataStore : IDataStore<SprintItem>
    {
        List<SprintItem> sprints;

        public SprintDataStore()
        {
            sprints = new List<SprintItem>();
            var mockSprints = new List<SprintItem>
            {
                new SprintItem { Id = Guid.NewGuid().ToString(), Title = "First item", Description="This is a sprint description 1." },
                new SprintItem { Id = Guid.NewGuid().ToString(), Title = "Second item", Description="This is a sprint description 2." },
            };

            foreach (var sprint in mockSprints)
            {
                sprints.Add(sprint);
            }
        }

        public async Task<bool> AddItemAsync(SprintItem sprint)
        {
            sprints.Add(sprint);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(SprintItem sprint)
        {
            var oldItem = sprints.Where((SprintItem arg) => arg.Id == sprint.Id).FirstOrDefault();
            sprints.Remove(oldItem);
            sprints.Add(sprint);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = sprints.Where((SprintItem arg) => arg.Id == id).FirstOrDefault();
            sprints.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<SprintItem> GetItemAsync(string id)
        {
            return await Task.FromResult(sprints.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<SprintItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(sprints);
        }
    }
}