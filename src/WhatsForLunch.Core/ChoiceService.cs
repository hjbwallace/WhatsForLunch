using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatsForLunch.Core
{
    public class ChoiceService : IChoiceService
    {
        private readonly Random _random;

        public ChoiceService()
        {
            _random = new Random();
        }

        public string MakeChoice(IDictionary<string, int> choices)
        {
            var choiceList = FlattenChoices(choices);
            var choice = choiceList[_random.Next(0, choiceList.Length)];
            return choice;
        }

        private string[] FlattenChoices(IDictionary<string, int> choices)
        {
            return choices.SelectMany(x => Enumerable.Range(1, x.Value).Select(y => x.Key)).ToArray();
        }
    }
}