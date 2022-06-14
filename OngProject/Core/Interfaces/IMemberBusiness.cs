using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Interfaces
{
    public interface IMemberBusiness
    {
        Task<int> CountMembers();
        Task<Member> GetById(int id);

        Task<PageList<MemberDto>> GetAll(int page, int pageSize, string url);

        Task<MemberDto> Insert(MemberInsertDto memberDto);

        Task<Response<MemberDto>> Update(MemberUpdateDto updateDto, int id);

        Task <MemberDto> Delete(int id);
    }
}
