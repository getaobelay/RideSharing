using RideSharing.Abstractions.Domain;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Drivers;

namespace RideSharing.Domain.Trips.Events
{
    public record TripCreatedEvent(Customer customer, Trip trip) : IDomainEvent;
    public record TripAddedEvent(Driver driver, Trip trip) : IDomainEvent;

}