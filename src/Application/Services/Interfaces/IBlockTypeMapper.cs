using Domain.Components.Blocks;
using System.Text.Json;

namespace Application.Services.Interfaces
{
    public interface IBlockTypeMapper
    {
        IEnumerable<IBlock> Map(List<dynamic> blocks);
        IEnumerable<IBlock> Map(string textBlocks);
    }
}
