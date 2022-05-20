using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly NewsRepository _newsRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public NewsRepository NewsRepository
        {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new NewsRepository(_context);
                }
                return _newsRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
