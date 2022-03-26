namespace RideSharing.Abstractions.Domain
{
    public interface IAggregateRoot : IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }

        void AddDomainEvent(IDomainEvent domainEvent);

        void ClearDomainEvents();
    }
}