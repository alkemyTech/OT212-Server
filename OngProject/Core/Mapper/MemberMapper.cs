using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class MemberMapper
    {
        public static MemberDto MapToMemberDto(this Member member)
        {
            return new MemberDto
            {
                Name = member.Name,
                Id = member.Id,
                Description = member.Description,
                FacebookUrl = member.FacebookUrl,
                InstagramUrl = member.InstagramUrl,
                LinkedinUrl = member.LinkedinUrl,
                Image = member.Image
            };
        }
        public static Member MapToMember(this MemberInsertDto member)
        {
            return new Member
            {
                Name = member.Name,
                Description = member.Description,
                FacebookUrl = member.FacebookUrl,
                InstagramUrl = member.InstagramUrl,
                LinkedinUrl = member.LinkedinUrl,
                Image = member.Image.FileName
            };
        }
    }
}
