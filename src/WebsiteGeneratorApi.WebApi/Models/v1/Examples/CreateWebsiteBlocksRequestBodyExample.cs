using Domain.Components.Blocks;
using Swashbuckle.AspNetCore.Filters;

namespace WebsiteGeneratorApi.WebApi.Models.v1.Examples
{
    public class CreateWebsiteBlocksRequestBodyExample : IExamplesProvider<List<IBlock>>
    {
        public List<IBlock> GetExamples()
        {
            return new List<IBlock>()
                {
                    BlockExamples.HeaderBlockExample,
                    BlockExamples.HeroBlockExample,
                    BlockExamples.ServicesBlockExample
                };
        }
    }
}
