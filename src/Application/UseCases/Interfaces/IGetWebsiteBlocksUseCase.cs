using Domain.Components.Blocks;

namespace Application.UseCases.Interfaces
{
    public interface IGetWebsiteBlocksUseCase : IUseCase<string, IEnumerable<IBlock>> { }
}
