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
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task SoftDeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            _context.Set<T>().Update(entity);
        }

        public Task<T> GetAsync(QueryProperty<T> query)
        {
            var source = ApplyQuery(query, _context.Set<T>().AsQueryable());

            return source.FirstOrDefaultAsync();
        }

        public Task<List<T>> GetAllAsync(QueryProperty<T> query)
        {
            var source = ApplyQuery(query, _context.Set<T>().AsQueryable());

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

            return source.Skip(query.Skip)
                        .Take(query.Take);
        }
    }
}
