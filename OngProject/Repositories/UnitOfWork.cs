﻿using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;

namespace OngProject.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        private readonly Repository<News> _newsRepository;

        private readonly Repository<Categories> _categoriesRepository;

        private Repository<Testimonials> _testimonialsRepository;

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

        public IRepository<Testimonials> TestimonialsRepository
        {
            get{
                if(_testimonialsRepository == null) 
                    _testimonialsRepository = new Repository<Testimonials>(_context);
                return _testimonialsRepository;
            }
        }
    }
}
