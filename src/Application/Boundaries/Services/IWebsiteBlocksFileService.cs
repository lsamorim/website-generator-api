using Domain.Components.Blocks;
using System.Text.Json;

namespace Application.Boundaries.Services
{
    public interface IWebsiteBlocksFileService
    {
        Task CreateAsync(string key, IEnumerable<IBlock> blocks, CancellationToken cancellationToken);

        Task<string> GetAsync(string key, CancellationToken cancellationToken);
    }
}
