using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public class CommentBusiness : ICommentBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public CommentBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteComment(int id)
        {
            Comment comment = _unitOfWork.CommentRepository.GetById(id);
            _unitOfWork.CommentRepository.Delete(comment);
            _unitOfWork.Save();
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _unitOfWork.CommentRepository.GetAll();
        }

        public Comment GetComment(int id)
        {
            return _unitOfWork.CommentRepository.GetById(id);
        }

        public void InsertComment(Comment comment)
        {
            _unitOfWork.CommentRepository.Insert(comment);
            _unitOfWork.Save();
        }

        public void UpdateComment(Comment comment)
        {
            _unitOfWork.CommentRepository.Update(comment);
            _unitOfWork.Save();
        }
    }
}
