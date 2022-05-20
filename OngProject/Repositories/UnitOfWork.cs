using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Repository<News> _newsRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public Repository<News> NewsRepository
        {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new Repository<News>(_context);
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
