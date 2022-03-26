using RideSharing.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharing.Abstractions.Repositories
{
    public interface IRepository<T> : IQueryRepository<T>, ICommandRepository<T>
        where T : Entity
    {
        Task SaveChangesAsync();
    }

}
