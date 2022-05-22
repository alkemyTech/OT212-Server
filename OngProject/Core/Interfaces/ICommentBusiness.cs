using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Interfaces
{
    public interface ICommentBusiness
    {
        public IEnumerable<Comment> GetAllComments();

        public Comment GetComment(int id);

        public void InsertComment(Comment comment);

        public void UpdateComment(int id, Comment comment);

        public void DeleteComment(int id);
    }
}
