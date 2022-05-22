using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        private Repository<News> _newsRepository;

        private Repository<Categories> _categoriesRepository;

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


        private IRepository<Role> _roleRepository;
        public IRepository<Role> RoleRepository
        {
            get
            { 
                if (_roleRepository == null)
                    _roleRepository = new Repository<Role>(_context);
                return _roleRepository; 
            }
        }


        private IRepository<Organization> _organizationRepository;
        public IRepository<Organization> OrganizationRepository
        {
            get 
            {
                if (_organizationRepository == null)
                    _organizationRepository = new Repository<Organization>(_context);

                return _organizationRepository; 
            }
        }

        private IRepository<Comment> _commentRepository;
        public IRepository<Comment> CommentRepository
        {
            get
            {
                if(_commentRepository == null)
                    _commentRepository = new Repository<Comment>(_context);
                return _commentRepository;
            }
        }

        private IRepository<Slide> _slideRepository;
        public IRepository<Slide> SlideRepository
        {
            get
            {
                if(_slideRepository == null)
                    _slideRepository = new Repository<Slide>(_context);

                return _slideRepository;
            }
        }

        private IRepository<Activity> _activityRepository;
        public IRepository<Activity> ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                    _activityRepository = new Repository<Activity>(_context);

                return _activityRepository;
            }
        }

    }
}
