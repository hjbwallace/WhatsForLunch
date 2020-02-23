using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhatsForLunch.Core
{
    public interface IChoiceService
    {
        string MakeChoice(IEnumerable<Choice> choices);

        Task<IList<Choice>> GetExistingChoicesAsync();

        Task SaveChoicesAsync(IList<Choice> choices);
    }
}