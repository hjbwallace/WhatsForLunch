using System.Collections.Generic;
using System.Linq;

namespace WhatsForLunch.Core
{
    public static class ChoiceExtensions
    {
        public static string[] GetWeightedList(this IEnumerable<Choice> choices)
        {
            return choices
                .Where(x => x.Weighting >= 1)
                .SelectMany(x => Enumerable.Range(1, x.Weighting).Select(y => x.Name))
                .ToArray();
        }
    }
}