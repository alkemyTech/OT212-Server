using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
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
