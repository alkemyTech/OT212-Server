using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Repository<Categories> _categoriesRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public Repository<Categories> CategoriesRepository
        {
            get
            {
                if (_categoriesRepository == null)
                {
                    _categoriesRepository = new Repository<Categories>(_context);
                }
                return _categoriesRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private IRepository<Organization> _organizationRepository;
        public IRepository<Organization> OrganizationRepository
        {
            get {
                if (_organizationRepository == null)
                    _organizationRepository = new Repository<Organization>(_context);

                return _organizationRepository; 
            }
        }
    }
}
