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

        public async Task<IEnumerable<T>> GetAllAsync() => await dbContext.Set<T>().ToListAsync();

        public async Task<T> GetAsync(int id) => await dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id) ?? throw new NullReferenceException();

        public async Task AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
