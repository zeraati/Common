namespace MediatR;
public interface ICommand : IRequest;
public interface ICommandHandler<TCommand>: IRequestHandler<TCommand> where TCommand : ICommand;

public interface ICommand<out TResult> : IRequest<TResult>;
public interface ICommandHandler<TCommand, TResult>: IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>;

public record CreateCommandResult(long Id);
