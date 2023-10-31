using Application.Boundaries.Services;
using Application.Services.Interfaces;
using Application.UseCases.Implementations.CreateWebsiteBlocks.Models;
using Application.UseCases.Interfaces;

namespace Application.UseCases.Implementations.CreateWebsiteBlocks
{
    public class CreateWebsiteBlocksUseCase : ICreateWebsiteBlocksUseCase
    {
        private readonly IBlockTypeMapper _blockTypeMapper;
        private readonly IWebsiteBlocksFileService _websiteBlocksFileService;

        public CreateWebsiteBlocksUseCase(
            IBlockTypeMapper blockTypeMapper,
            IWebsiteBlocksFileService websiteBlocksFileService)
        {
            _blockTypeMapper = blockTypeMapper;
            _websiteBlocksFileService = websiteBlocksFileService;
        }

        public async Task ExecuteAsync(
            CreateWebsiteBlocksInput input,
            CancellationToken cancellationToken)
        {
            var blocks = _blockTypeMapper.Map(input.Blocks);
            await _websiteBlocksFileService.CreateAsync(input.Key, blocks, cancellationToken);
        }
    }
}
