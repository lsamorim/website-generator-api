namespace Application.UseCases.Interfaces
{
    public interface IUseCase<TInput>
    {
        Task ExecuteAsync(TInput input, CancellationToken cancellationToken);
    }

    public interface IUseCase<TInput, TOutput>
    {
        Task<TOutput> ExecuteAsync(TInput input, CancellationToken cancellationToken);
    }
}
