using Application.Services.Interfaces;
using Domain.Components.Blocks;
using Newtonsoft.Json;
using System.Reflection;

namespace Application.Services.Implementations
{
    public class BlockTypeMapper : IBlockTypeMapper
    {
        private Dictionary<string, Type> BlockTypeMapping = new Dictionary<string, Type>();

        public BlockTypeMapper()
        {
            var blockType = typeof(IBlock);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => !p.IsInterface && blockType.IsAssignableFrom(p));

            BlockTypeMapping = types.ToDictionary(
                type => type
                    .GetProperty("Id", BindingFlags.Static | BindingFlags.Public)
                    .GetValue(null).ToString(),
                type => type);
        }

        public IEnumerable<IBlock> MapBlocks(List<dynamic> blocks)
        {
            return blocks.Select(MapBlock);
        }

        public IEnumerable<IBlock> MapTextBlocks(string textBlocks)
        {
            var dynamicBlocks = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(textBlocks);

            return dynamicBlocks.Select(MapBlock);
        }
        public IBlock MapBlock(dynamic block)
        {
            var typeId = block.Id.ToString();
            return (IBlock)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(block), BlockTypeMapping[typeId]);
        }
    }
}
