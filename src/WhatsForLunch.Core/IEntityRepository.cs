namespace WhatsForLunch.Core
{
    public interface IEntityRepository<TEntity>
    {
        Task<TEntity?> GetAsync();

        Task SaveAsync(TEntity entity);
    }
}