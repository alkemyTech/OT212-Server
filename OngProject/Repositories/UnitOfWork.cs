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

        private IRepository<Role> _roleRepository;
        public IRepository<Role> RoleRepository
        {
            get {
                if (_roleRepository == null)
                    _roleRepository = new Repository<Role>(_context);
                return _roleRepository; 
            }
        }

    }
}
