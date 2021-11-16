using Microsoft.JSInterop;
using System.Text.Json;
using WhatsForLunch.Core;

namespace WhatsForLunch.Web.Services
{
    public class LocalStorageEntityRepository<TEntity> : IEntityRepository<TEntity>
    {
        private const string _getItemMethod = "localStorage.getItem";
        private const string _removeItemMethod = "localStorage.removeItem";
        private const string _setItemMethod = "localStorage.setItem";

        private readonly IJSRuntime _js;
        private readonly string _entityKey;

        public LocalStorageEntityRepository(IJSRuntime js, string? entityKey = null)
        {
            _js = js;
            _entityKey = entityKey ?? typeof(TEntity).Name;
        }

        public virtual async Task<TEntity?> GetAsync()
        {
            var entityJson = await _js.InvokeAsync<string>(_getItemMethod, _entityKey);

            if (entityJson == null)
                return default;

            return JsonSerializer.Deserialize<TEntity>(entityJson);
        }

        public async Task SaveAsync(TEntity entity)
        {
            if (entity == null)
            {
                await _js.InvokeAsync<object>(_removeItemMethod, _entityKey);
                return;
            }

            var entityJson = JsonSerializer.Serialize(entity);
            await _js.InvokeAsync<object>(_setItemMethod, _entityKey, entityJson);
        }
    }
}