using Application.Boundaries.Services;
using Application.Services.Interfaces;
using Application.UseCases.Implementations.UpdateWebsiteBlocksSection.Models;
using Application.UseCases.Interfaces;
using Domain.Components.Blocks;

namespace Application.UseCases.Implementations.UpdateWebsiteBlocksSection
{
    public class UpdateWebsiteBlocksSectionUseCase : IUpdateWebsiteBlocksSectionUseCase
    {
        private readonly IBlockTypeMapper _blockTypeMapper;
        private readonly IWebsiteBlocksFileService _websiteBlocksFileService;

        public UpdateWebsiteBlocksSectionUseCase(IBlockTypeMapper blockTypeMapper, IWebsiteBlocksFileService websiteBlocksFileService)
        {
            _blockTypeMapper = blockTypeMapper;
            _websiteBlocksFileService = websiteBlocksFileService;
        }

        public async Task ExecuteAsync(UpdateWebsiteBlocksSectionInput input, CancellationToken cancellationToken)
        {
            var textBlocks = await _websiteBlocksFileService.GetAsync(input.Key, cancellationToken);
            var blocks = _blockTypeMapper.MapTextBlocks(textBlocks);

            IBlock updatedBlock = _blockTypeMapper.MapBlock(input.Block);
            blocks = blocks.Select(b => b.BlockOrder == input.SectionId ? updatedBlock : b);

            await _websiteBlocksFileService.UpdateAsync(input.Key, blocks, cancellationToken);
        }
    }
}
