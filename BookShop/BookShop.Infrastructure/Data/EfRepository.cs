using BookShop.Core.Entities;
using BookShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Data
{
    public abstract class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly BookShopDbContext db;

        public EfRepository(BookShopDbContext db) => this.db = db;

        public async Task<T> GetByIdAsync(int id)
           => await db.Set<T>().FindAsync(id);


        public async Task UpdateAsync(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            db.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<ICollection<T>> ListAllAsync()
            => await db.Set<T>().ToListAsync();

        public async Task<ICollection<T>> ListAsync(Expression<Func<T, bool>> predicate)
            => await db.Set<T>().Where(predicate).ToListAsync();

        public async Task<int> CountAsync()
            => await db.Set<T>().CountAsync();

        public async Task<bool> ExistsAsync(int id)
            => await db.Set<T>().AnyAsync(e => e.Id == id);
    }
}
