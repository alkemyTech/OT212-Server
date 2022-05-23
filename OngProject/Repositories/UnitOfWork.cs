using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IRepository<Category> _categoryRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public Repository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new Repository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
