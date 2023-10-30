using Application.Services.Interfaces;
using Domain.Components.Blocks;
using System.Reflection;
using System.Text.Json;

namespace Application.Services.Implementations
{
    public class BlockTypeMapper : IBlockTypeMapper
    {
        private Dictionary<string, Type> BlockTypeMapping = new Dictionary<string, Type>();

        public BlockTypeMapper()
        {
            var blockType = typeof(Block);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => !p.IsInterface && blockType.IsAssignableFrom(p));

            BlockTypeMapping = types.ToDictionary(
                type => type
                    .GetProperty("Id", BindingFlags.Static | BindingFlags.Public)
                    .GetValue(null).ToString(),
                type => type);
        }

        public IEnumerable<Block> Map(List<dynamic> blocks)
        {
            return blocks.Select(block =>
            {
                var element = (JsonElement)block;
                var typeId = element.GetProperty("Id").ToString();
                return (Block)element.Deserialize(BlockTypeMapping[typeId]);
            });
        }
    }
}
