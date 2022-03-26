using Microsoft.EntityFrameworkCore;
using RideSharing.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RideSharing.Abstractions.Repositories
{
    public abstract class Repository<TContext, T> : IRepository<T>
        where T : Entity
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<T> _dbSet;
        protected Repository(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbSet.AddAsync(entity);

        }

        public Task<int> CountAll() => _dbSet.CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate) => _dbSet.CountAsync(predicate);
        public async Task Delete(Guid Id)
        {
            T entityToDelete = await GetByIdAsync(Id);
            Delete(entityToDelete);
        }
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);

        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            query = query.Include(includeString);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                               params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            foreach (var includeProperty in includes)
            {
                query = query.IncludeMultiple(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
        public async Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
            => await _dbSet.Where(e => e.Id == id).IncludeMultiple(includes).SingleOrDefaultAsync();

        public async Task<T> GetByIdAsync(Guid id, string include) =>
            await _dbSet.Where(e => e.Id == id).Include(include).SingleOrDefaultAsync();

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}

