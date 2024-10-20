namespace MediatR;
public interface IRequestValidator<TRequest, TResult> where TRequest : IRequest<TResult>
{
    Task Validate(TRequest request,CancellationToken cancellation);
}