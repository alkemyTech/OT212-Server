using System.Collections.Generic;
using OngProject.Entities;

namespace OngProject.Core.Interfaces
{
    public interface IMemberBusiness
    {
        Member GetById(int id);

        List<Member> GetAll();

        void Insert(Member entity);

        void Update(Member entity);

        void Delete(Member entity);
    }
}
