namespace MediatR;
public interface IQuery<out TResult> : IRequest<TResult>;
public interface IQueryHandler<TQueryRequest, TResult> : IRequestHandler<TQueryRequest, TResult> where TQueryRequest : IQuery<TResult>;