namespace MediatR;
public class RequestHandlerValidatorDecorator<TRequest, TResult>
    : IRequestHandler<TRequest, TResult> where TRequest : IRequest<TResult>
{
    private readonly IRequestHandler<TRequest, TResult> _decoratedHandler;
    private readonly IRequestValidator<TRequest, TResult> _validator;
    public RequestHandlerValidatorDecorator(IRequestHandler<TRequest, TResult> decoratedHandler,
        IRequestValidator<TRequest, TResult> validator = null)
    {
        _decoratedHandler = decoratedHandler;
        _validator = validator;
    }

    public async Task<TResult> Handle(TRequest command, CancellationToken cancellationToken)
    {
        if (_validator != null) await _validator.Validate(command);
        return await _decoratedHandler.Handle(command, cancellationToken);
    }
}