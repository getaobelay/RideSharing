using MediatR;

namespace RideSharing.Abstractions.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    { }
}
