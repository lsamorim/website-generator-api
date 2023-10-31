using System.Text.Json;

namespace Application.UseCases.Implementations.CreateWebsiteBlocks.Models
{
    public class CreateWebsiteBlocksInput
    {
        public string Key { get; }
        public List<dynamic> Blocks { get; } = new List<dynamic>();

        public CreateWebsiteBlocksInput(string key, List<dynamic> blocks)
        {
            Key = key;
            Blocks = blocks;
        }
    }
}
