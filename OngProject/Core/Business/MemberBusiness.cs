using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
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
      

        public async Task<Response<MemberDto>> Update(MemberUpdateDto updateDto, int id)
        {
            try
            {
                var member = await _unitOfWork.MemberRepository.GetByIdAsync(id);
                
                if(member == null)
                {
                    return new Response<MemberDto>
                    {
                        Succeeded = false,
                        Message = ResponseMessage.NotFound,
                        Errors = new string[] { "Member not found!" }
                    };
                }

                if (updateDto.Image != null)
                {
                    var img = await Helper.ImageUploadHelper.UploadImageToS3(updateDto.Image);

                    if (string.IsNullOrEmpty(img))
                    {
                        return new Response<MemberDto>
                        {
                            Succeeded = false,
                            Message = ResponseMessage.Error,
                            Errors = new string[] { "Can't update image." }
                        };
                    }

                    member.Image = img;
                }
                
                member = updateDto.MapToMember(member);
                await _unitOfWork.MemberRepository.UpdateAsync(member);
                await _unitOfWork.SaveAsync();

                return new Response<MemberDto>
                {
                    Data = member.MapToMemberDto(),
                    Succeeded = true,
                    Message = ResponseMessage.Success
                };
            }
            catch (Exception ex)
            {
                return new Response<MemberDto>
                {
                    Succeeded = false,
                    Message = ResponseMessage.UnexpectedErrors,
                    Errors = new string[] 
                    { 
                        "Unexpected error when try to update member.",
                        $"Rason: {ex.Message}"
                    }
                };
            }
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
