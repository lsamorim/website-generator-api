using Domain.Components.Blocks;

namespace Application.Services.Interfaces
{
    public interface IBlockTypeMapper
    {
        IEnumerable<IBlock> MapBlocks(List<dynamic> blocks);
        IEnumerable<IBlock> MapTextBlocks(string textBlocks);
        IBlock MapBlock(dynamic block);
    }
}
