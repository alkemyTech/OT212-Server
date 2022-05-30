using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CommentBusiness : ICommentBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public CommentBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Comment>> GetAll()
        {
            var repository = _unitOfWork.CommentRepository;

            return await repository.GetAllAsync();
        }

        public Task<Comment> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Comment entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Comment entity)
        {
            throw new System.NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
