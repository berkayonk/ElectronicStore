using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectronicStore.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DatabaseContext context;

        public EntityBaseRepository(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task addAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task deleteAsync(int id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<T> GetIDAsync(int id)
        {
            var result = await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await context.Set<T>().ToListAsync();
            return result;
        }

        public async Task updateAsync(int id, T entity)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] expressions)
        {
            IQueryable<T> ts = context.Set<T>();
            ts = expressions.Aggregate(ts, (current, expressions) => current.Include(expressions));
            return await ts.ToListAsync();
        }
    }
}
