using Microsoft.JSInterop;
using System.Collections.Generic;
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