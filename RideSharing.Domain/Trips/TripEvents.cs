using RideSharing.Abstractions.Domain;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Drivers;

namespace RideSharing.Domain.Trips
{
    public record TripCreatedEvent(Customer customer, Trip trip) : IDomainEvent;
    public record TripAddedEvent(DriverCar driver, Trip trip) : IDomainEvent;
    public record TripCompletedEvent(Trip trip) : IDomainEvent;
    public record TripStartedEvent(Trip trip) : IDomainEvent;



}