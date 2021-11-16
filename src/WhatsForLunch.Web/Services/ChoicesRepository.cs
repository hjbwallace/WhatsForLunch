using Microsoft.JSInterop;
using WhatsForLunch.Core;

namespace WhatsForLunch.Web.Services
{
    public class ChoicesRepository : LocalStorageEntityRepository<IList<Choice>>, IChoicesRepository
    {
        public ChoicesRepository(IJSRuntime js) : base(js, "Choices")
        {
        }
    }
}