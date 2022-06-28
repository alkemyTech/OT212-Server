using Microsoft.EntityFrameworkCore;
using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var source = _context.Set<T>().Where(x => !x.IsDeleted);
            return await source.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            var source = _context.Set<T>().Where(x => !x.IsDeleted);
            return await source.ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            entity.LastModified = DateTime.UtcNow;
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.LastModified = DateTime.UtcNow;
            _context.Set<T>().Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            entity.LastModified = DateTime.UtcNow;
            _context.Set<T>().Remove(entity);
        }

        public async Task SoftDeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            entity.LastModified = DateTime.UtcNow;
            _context.Set<T>().Update(entity);
        }

        public Task<T> GetAsync(QueryProperty<T> query)
        {
            var source = _context.Set<T>().AsQueryable().Where(x => !x.IsDeleted);
            source = ApplyQuery(query, source);
            
            return source.FirstOrDefaultAsync();
        }

        public Task<List<T>> GetAllAsync(QueryProperty<T> query)
        {
            var source = _context.Set<T>().AsQueryable().Where(x => !x.IsDeleted);
            source = ApplyQuery(query, source);
            
            return source.ToListAsync();
        }

        private static IQueryable<T> ApplyQuery(QueryProperty<T> query, IQueryable<T> source)
        {
            if (query is null)
                return source;

            if (query.Where is not null)
                source = source.Where(query.Where);

            foreach (var property in query.Includes)
            {
                source = source.Include(property);
            }

            if(query.Skip > 0)
                source = source.Skip(query.Skip);

            if (query.Take > 0)
                source = source.Take(query.Take);

            return source;
        }

        public async Task<int> Count()
        {
            return await _context.Set<T>().Where(x => !x.IsDeleted).CountAsync();
        }
    }
}
