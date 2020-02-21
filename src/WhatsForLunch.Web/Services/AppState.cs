using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsForLunch.Core;

namespace WhatsForLunch.Web.Services
{
    public class AppState
    {
        private readonly IChoiceService _choiceService;

        public AppState(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }

        public event Action OnChange;

        public IList<Choice> Choices { get; private set; } = new List<Choice>
        {
            new Choice { Name = "Option 1", Weighting = 1 },
            new Choice { Name = "Option 2", Weighting = 2 },
            new Choice { Name = "Option 3", Weighting = 3 },
        };

        public string CurrentChoice { get; private set; }

        public async Task GetChoiceAsync()
        {
            if (Choices?.Any() != true)
                return;

            CurrentChoice = _choiceService.MakeChoice(Choices);
            Console.WriteLine($"Made choice: {CurrentChoice}");

            NotifyStateChanged();

            await Task.CompletedTask;
        }

        public void AddChoice(Choice choice)
        {
            if (Choices.Any(x => x.Name == choice.Name))
                return;

            Choices.Add(choice);
            NotifyStateChanged();
        }

        public void RemoveChoice(Choice choice)
        {
            Choices.Remove(choice);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}