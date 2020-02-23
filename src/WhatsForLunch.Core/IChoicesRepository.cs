using System.Collections.Generic;

namespace WhatsForLunch.Core
{
    public interface IChoicesRepository : IEntityRepository<IList<Choice>> { }
}