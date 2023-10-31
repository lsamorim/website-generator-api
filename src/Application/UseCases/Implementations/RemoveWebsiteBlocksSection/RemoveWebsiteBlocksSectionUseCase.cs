using Application.Boundaries.Services;
using Application.Services.Interfaces;
using Application.UseCases.Implementations.RemoveWebsiteBlocksSection.Models;
using Application.UseCases.Interfaces;

namespace Application.UseCases.Implementations.RemoveWebsiteBlocksSection
{
    public class RemoveWebsiteBlocksSectionUseCase : IRemoveWebsiteBlocksSectionUseCase
    {
        private readonly IBlockTypeMapper _blockTypeMapper;
        private readonly IWebsiteBlocksFileService _websiteBlocksFileService;

        public RemoveWebsiteBlocksSectionUseCase(
            IBlockTypeMapper blockTypeMapper,
            IWebsiteBlocksFileService websiteBlocksFileService)
        {
            _blockTypeMapper = blockTypeMapper;
            _websiteBlocksFileService = websiteBlocksFileService;
        }

        public async Task ExecuteAsync(
            RemoveWebsiteBlocksSectionInput input, 
            CancellationToken cancellationToken)
        {
            var textBlocks = await _websiteBlocksFileService.GetAsync(input.Key, cancellationToken);
            var blocks = _blockTypeMapper.MapTextBlocks(textBlocks);

            blocks = blocks.Where(b => b.BlockOrder != input.SectionId);

            if (blocks.Count() == 0) 
            {
                _websiteBlocksFileService.Delete(input.Key);
                return;
            }

            await _websiteBlocksFileService.UpdateAsync(input.Key, blocks, cancellationToken);
        }
    }
}
