using MediatR;

namespace RideSharing.Abstractions.Commands
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
      where TCommand : ICommandRequest<TResponse>
    {
    }
}
