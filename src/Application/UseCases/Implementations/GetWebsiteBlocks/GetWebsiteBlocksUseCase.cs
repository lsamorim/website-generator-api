using Application.Boundaries.Services;
using Application.Services.Interfaces;
using Application.UseCases.Interfaces;
using Domain.Components.Blocks;

namespace Application.UseCases.Implementations.GetWebsiteBlocks
{
    public class GetWebsiteBlocksUseCase : IGetWebsiteBlocksUseCase
    {
        private readonly IWebsiteBlocksFileService _websiteBlocksFileService;
        private readonly IBlockTypeMapper _blockTypeMapper;

        public GetWebsiteBlocksUseCase(IWebsiteBlocksFileService websiteBlocksFileService, IBlockTypeMapper blockTypeMapper)
        {
            _websiteBlocksFileService = websiteBlocksFileService;
            _blockTypeMapper = blockTypeMapper;
        }

        public async Task<IEnumerable<IBlock>> ExecuteAsync(string input, CancellationToken cancellationToken)
        {
            var textBlocks = await _websiteBlocksFileService.GetAsync(input, cancellationToken);
            return _blockTypeMapper.Map(textBlocks);
        }
    }
}
