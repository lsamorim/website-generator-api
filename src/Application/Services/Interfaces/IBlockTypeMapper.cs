using Domain.Components.Blocks;

namespace Application.Services.Interfaces
{
    public interface IBlockTypeMapper
    {
        IEnumerable<Block> Map(List<dynamic> blocks);
    }
}
