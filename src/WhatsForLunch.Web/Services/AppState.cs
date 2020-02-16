using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsForLunch.Web.Services
{
    public class AppState
    {
        public event Action OnChange;

        public IDictionary<string, int> Choices { get; private set; } = new Dictionary<string, int>
        {
            ["Option 1"] = 1,
            ["Option 2"] = 2
        };

        public string CurrentChoice { get; private set; }

        public async Task GetChoiceAsync()
        {
            if (Choices?.Any() != true)
                return;

            CurrentChoice = Choices.Keys.OrderBy(x => Guid.NewGuid()).First();
            Console.WriteLine($"Made choice: {CurrentChoice}");

            NotifyStateChanged();

            await Task.CompletedTask;
        }

        public void AddChoice(KeyValuePair<string, int> choice)
        {
            Choices.Add(choice);
            NotifyStateChanged();
        }

        public void RemoveChoice(string choice)
        {
            Choices.Remove(choice);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}