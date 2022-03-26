using RideSharing.Abstractions.Domain;

namespace RideSharing.Abstractions.Repositories
{
    public interface ICommandRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task Delete(Guid Id);
    }

}
