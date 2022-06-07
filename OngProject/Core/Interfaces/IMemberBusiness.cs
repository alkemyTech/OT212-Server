using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Interfaces
{
    public interface IMemberBusiness
    {
        Task<Member> GetById(int id);

        Task<List<Member>> GetAll();

        Task Insert(MemberInsertDto memberDto);

        Task Update(Member entity);

        Task Delete(Member entity);
    }
}
