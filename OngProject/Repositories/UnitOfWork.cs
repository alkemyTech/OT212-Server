using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly CategoriesRepository _categoriesRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public CategoriesRepository CategoriesRepository
        {
            get
            {
                if (_categoriesRepository == null)
                {
                    _categoriesRepository = new CategoriesRepository(_context);
                }
                return _categoriesRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
