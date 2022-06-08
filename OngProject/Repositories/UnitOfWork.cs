using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private IRepository<News> _newsRepository;
        public IRepository<News> NewsRepository
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

        private IRepository<Category> _categoryRepository;
        public IRepository<Category> CategoriesRepository
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

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
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


        private IRepository<Organization> _organizationRepository;
        public IRepository<Organization> OrganizationRepository
        {
            get {
                if (_organizationRepository == null)
                    _organizationRepository = new Repository<Organization>(_context);

                return _organizationRepository; 
            }
        }

        private IRepository<Testimonial> _testimonialRepository;
        public IRepository<Testimonial> TestimonialRepository
        {
            get{
                if(_testimonialRepository == null) 
                    _testimonialRepository = new Repository<Testimonial>(_context);
                return _testimonialRepository;
            }
        }


        private IRepository<User> _userRepository;
        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new Repository<User>(_context);

                return _userRepository;
            }
        }

        private IRepository<Member> _memberRepository;
        public IRepository<Member> MemberRepository
        {
            get {
                if (_memberRepository == null)
                    _memberRepository = new Repository<Member>(_context);

                return _memberRepository; 

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

        private IRepository<Contact> _contactRepository;
        public IRepository<Contact> ContactRepository
        {
            get
            {
                if(_contactRepository == null)
                    _contactRepository = new Repository<Contact>(_context);
                return _contactRepository;
            }
        }
    }
}
