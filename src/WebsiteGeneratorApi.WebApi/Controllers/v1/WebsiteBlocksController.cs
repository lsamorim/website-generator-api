using Application.UseCases.Implementations.CreateWebsiteBlocks.Models;
using Application.UseCases.Implementations.RemoveWebsiteBlocksSection.Models;
using Application.UseCases.Implementations.UpdateWebsiteBlocksSection.Models;
using Application.UseCases.Interfaces;
using Domain.Components.Blocks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel.DataAnnotations;
using System.Net;
using WebsiteGeneratorApi.WebApi.Helpers;
using WebsiteGeneratorApi.WebApi.Models.v1.Examples;

namespace WebsiteGeneratorApi.WebApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WebsiteBlocksController : ControllerBase
    {
        [HttpPost]
        [SwaggerRequestExample(typeof(List<IBlock>), typeof(CreateWebsiteBlocksRequestBodyExample))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(
            [Required][FromQuery] string key,
            [Required][FromBody] List<dynamic> blocks,
            [FromServices] ICreateWebsiteBlocksUseCase useCase,
            CancellationToken cancellationToken)
        {
            if (!KeyValidatorHelper.IsValid(key))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Message = "Invalid key" });
            }

            var input = new CreateWebsiteBlocksInput(key, blocks);
            await useCase.ExecuteAsync(input, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created, new { Key = key });
        }

        

        [HttpGet("{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string key,
            [FromServices] IGetWebsiteBlocksUseCase useCase,
            CancellationToken cancellationToken)
        {
            if (!KeyValidatorHelper.IsValid(key))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Message = "Invalid key" });
            }

            var output = await useCase.ExecuteAsync(key, cancellationToken);

            return Ok(output);
        }

        [HttpPut("{key}/sections/{sectionId}")]
        [SwaggerRequestExample(typeof(IBlock), typeof(UpdateWebsiteBlocksSectionRequestBodyExample))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] string key,
            [FromRoute] int sectionId,
            [Required][FromBody] dynamic block,
            [FromServices] IUpdateWebsiteBlocksSectionUseCase useCase,
            CancellationToken cancellationToken)
        {
            if (!KeyValidatorHelper.IsValid(key))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Message = "Invalid key" });
            }

            var input = new UpdateWebsiteBlocksSectionInput(key, sectionId, block);
            await useCase.ExecuteAsync(input, cancellationToken);

            return Ok();
        }

        [HttpDelete("{key}/sections/{sectionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] string key,
            [FromRoute] int sectionId,
            [FromServices] IRemoveWebsiteBlocksSectionUseCase useCase,
            CancellationToken cancellationToken)
        {
            if (!KeyValidatorHelper.IsValid(key))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Message = "Invalid key" });
            }

            var input = new RemoveWebsiteBlocksSectionInput(key, sectionId);
            await useCase.ExecuteAsync(input, cancellationToken);

            return Ok();
        }
    }
}
