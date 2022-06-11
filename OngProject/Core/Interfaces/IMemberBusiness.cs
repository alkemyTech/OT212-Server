using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Interfaces
{
    public interface IMemberBusiness
    {
        Task<Member> GetById(int id);

        Task<List<Member>> GetAll();

        Task<MemberDto> Insert(MemberInsertDto memberDto);

        Task<Response<MemberDto>> Update(MemberUpdateDto updateDto, int id);

        Task <MemberDto> Delete(int id);
    }
}
