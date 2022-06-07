using OngProject.Core.Helper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Threading.Tasks;

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
        public async static Task<Member> MapToInsertMemberDto(this MemberInsertDto member)
        {
            return new Member
            {
                Name = member.Name,
                Description = member.Description,
                FacebookUrl = member.FacebookUrl,
                InstagramUrl = member.InstagramUrl,
                LinkedinUrl = member.LinkedinUrl,
                Image = await ImageUploadHelper.UploadImageToS3(member.Image)
            };
        }
        public static MemberDto MapToMemberNewDto(this Member entity)
        {
            return new MemberDto
            {
                Name = entity.Name,
                Description = entity.Description,
                Image = entity.Image,
            };
        }
    }
}
