namespace Application.UseCases.Interfaces
{
    public interface IUseCase<TInput>
    {
        Task ExecuteAsync(TInput input, CancellationToken cancellationToken);
    }
}
