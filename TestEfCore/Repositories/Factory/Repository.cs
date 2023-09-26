using Microsoft.EntityFrameworkCore;
using testEfCore.Models;

namespace testEfCore.Repositories.Factory
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext dbContext;

        protected Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAll() => await dbContext.Set<T>().ToListAsync();

        public async Task<T?> Get(int id) => await dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);

        public async Task Add(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
