using System.Collections.Generic;

namespace WhatsForLunch.Core
{
    public interface IChoiceService
    {
        string MakeChoice(IDictionary<string, int> choices);
    }
}