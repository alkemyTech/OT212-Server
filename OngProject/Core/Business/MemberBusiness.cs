using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;

namespace OngProject.Core.Business
{
    public class MemberBusiness : IMemberBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public MemberBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Member>> GetAll()
        {
            return await _unitOfWork.MemberRepository.GetAllAsync();
        }

        public Task<Member> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MemberDto> Insert(MemberInsertDto memberDto)
        {
            var member = await MemberMapper.MapToInsertMemberDto(memberDto);
            await _unitOfWork.MemberRepository.InsertAsync(member);
            await _unitOfWork.SaveAsync();

            return MemberMapper.MapToMemberDto(member);
        }
      

        public Task Update(Member entity)
        {
            throw new System.NotImplementedException();
        }
        public Task Delete(Member entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
