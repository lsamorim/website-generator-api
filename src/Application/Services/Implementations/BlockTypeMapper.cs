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

        public IEnumerable<IBlock> Map(List<dynamic> blocks)
        {
            return blocks.Select(block =>
            {
                var typeId = block.Id.ToString();
                return (IBlock)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(block), BlockTypeMapping[typeId]);
            });
        }

        public IEnumerable<IBlock> Map(string textBlocks)
        {
            var dynamicBlocks = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(textBlocks);

            return dynamicBlocks.Select(block =>
            {
                var typeId = block.Id.ToString();
                return (IBlock)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(block), BlockTypeMapping[typeId]);
            });
        }
    }
}
