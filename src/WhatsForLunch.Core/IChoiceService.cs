using System.Collections.Generic;

namespace WhatsForLunch.Core
{
    public interface IChoiceService
    {
        string MakeChoice(IEnumerable<Choice> choices);
    }
}