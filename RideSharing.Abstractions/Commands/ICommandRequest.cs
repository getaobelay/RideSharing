using MediatR;

namespace RideSharing.Abstractions.Commands
{
    public interface ICommandRequest<out TResponse> : IRequest<TResponse> { }

}
