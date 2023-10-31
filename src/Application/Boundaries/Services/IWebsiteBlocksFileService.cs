using Domain.Components.Blocks;

namespace Application.Boundaries.Services
{
    public interface IWebsiteBlocksFileService
    {
        Task CreateAsync(string key, IEnumerable<IBlock> blocks, CancellationToken cancellationToken);

        Task<string> GetAsync(string key, CancellationToken cancellationToken);

        Task UpdateAsync(string key, IEnumerable<IBlock> blocks, CancellationToken cancellationToken);

        void Delete(string key);
    }
}
