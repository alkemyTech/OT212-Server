﻿using System.Collections.Generic;
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

        public Task Insert(Member entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Member entity)
        {
            throw new System.NotImplementedException();
        }
        public async Task<MemberDto> Delete(int id)
        {
            var member = await _unitOfWork.MemberRepository.GetByIdAsync(id);

            if ((member != null) && (member.IsDeleted == false))
            {
                var memberDto = MemberMapper.MapToMemberDto(member);
                await _unitOfWork.MemberRepository.SoftDeleteAsync(member);
                await _unitOfWork.SaveAsync();

                return memberDto;
            }
            else
                throw new KeyNotFoundException();
        }
    }
}
