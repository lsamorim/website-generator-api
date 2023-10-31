using Domain.Components.Blocks;
using Swashbuckle.AspNetCore.Filters;

namespace WebsiteGeneratorApi.WebApi.Models.v1.Examples
{
    public class UpdateWebsiteBlocksSectionRequestBodyExample : IMultipleExamplesProvider<IBlock>
    {
        public IEnumerable<SwaggerExample<IBlock>> GetExamples()
        {
            yield return SwaggerExample
                .Create("HeaderBlockExample", (IBlock)BlockExamples.HeaderBlockExample);

            yield return SwaggerExample
                .Create("HeroBlockExample", (IBlock)BlockExamples.HeroBlockExample);

            yield return SwaggerExample
                .Create("ServicesBlockExample", (IBlock)BlockExamples.ServicesBlockExample);
        }
    }
}
