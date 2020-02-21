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

        public string MakeChoice(IEnumerable<Choice> choices)
        {
            var choiceList = choices.GetWeightedList();
            var choice = choiceList[_random.Next(0, choiceList.Length)];
            return choice;
        }
    }
}