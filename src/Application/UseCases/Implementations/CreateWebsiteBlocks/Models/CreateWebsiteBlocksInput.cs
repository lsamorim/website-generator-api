using Domain.Components.Blocks;

namespace Application.UseCases.Implementations.CreateWebsiteBlocks.Models
{
    public class CreateWebsiteBlocksInput
    {
        public IEnumerable<Block> Blocks { get; } = Array.Empty<Block>();

        public CreateWebsiteBlocksInput(IEnumerable<Block> blocks)
        {
            Blocks = blocks;
        }
    }
}
