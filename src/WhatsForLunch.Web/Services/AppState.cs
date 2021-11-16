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

        public event Action? OnChange;

        public IList<Choice> Choices { get; private set; } = new List<Choice>();

        public string? CurrentChoice { get; private set; }

        public async Task GetExistingChoicesAsync()
        {
            Choices = (await _choiceService.GetExistingChoicesAsync())?.ToList() ?? new List<Choice>();
        }

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
            OnChoicesUpdated();
        }

        public void RemoveChoice(Choice choice)
        {
            Choices.Remove(choice);
            OnChoicesUpdated();
        }

        private void OnChoicesUpdated()
        {
            _choiceService.SaveChoicesAsync(Choices);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}