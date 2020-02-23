using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhatsForLunch.Core
{
    public class ChoiceService : IChoiceService
    {
        private readonly Random _random;
        private readonly IChoicesRepository _choicesRepository;

        public ChoiceService(IChoicesRepository choicesRepository)
        {
            _random = new Random();
            _choicesRepository = choicesRepository;
        }

        public string MakeChoice(IEnumerable<Choice> choices)
        {
            var choiceList = choices.GetWeightedList();
            var choice = choiceList[_random.Next(0, choiceList.Length)];
            return choice;
        }

        public async Task<IList<Choice>> GetExistingChoicesAsync()
        {
            return await _choicesRepository.GetAsync();
        }

        public async Task SaveChoicesAsync(IList<Choice> choices)
        {
            await _choicesRepository.SaveAsync(choices);
        }
    }
}