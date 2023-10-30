using Application.Services.Implementations;
using Application.Services.Interfaces;
using Application.UseCases.Implementations.CreateWebsiteBlocks.Models;
using Application.UseCases.Interfaces;
using Domain;
using Domain.Components.Blocks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace WebsiteGeneratorApi.WebApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WebsiteBlocksController : ControllerBase
    {
        private readonly IBlockTypeMapper _blockTypeMapper;

        public WebsiteBlocksController(IBlockTypeMapper blockTypeMapper)
        {
            _blockTypeMapper = blockTypeMapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromQuery] string key,
            [FromBody] List<dynamic> blocks,
            [FromServices] ICreateWebsiteBlocksUseCase useCase,
            CancellationToken cancellationToken)
        {
            var blocksList = _blockTypeMapper.Map(blocks);

            var input = new CreateWebsiteBlocksInput(blocksList);

            await useCase.ExecuteAsync(input, cancellationToken);

            var result = JsonConvert.SerializeObject(input.Blocks);
            return Ok(result);
        }
    }
}
