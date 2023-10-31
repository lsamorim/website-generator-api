using Application.UseCases.Implementations.CreateWebsiteBlocks.Models;
using Application.UseCases.Implementations.RemoveWebsiteBlocksSection.Models;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using WebsiteGeneratorApi.WebApi.Helpers;

namespace WebsiteGeneratorApi.WebApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WebsiteBlocksController : ControllerBase
    {
        [HttpPost]
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

            return Ok(input.Key);
        }

        [HttpGet("{key}")]
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

        [HttpDelete("{key}/sections/{sectionId}")]
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
