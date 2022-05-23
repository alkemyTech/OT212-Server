using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    [Table("Comments")]
    public class Comment : Entity
    {
        [ForeignKey("Member"), Column("user_id"), Required]
        public int MemberId { get; set; }

        public Member Member { get; set; }


        [Required, StringLength(255), Column(TypeName = "varchar")]
        public string Body { get; set; }

        [ForeignKey("News"), Column("news_id"), Required]
        public int NewsId { get; set; }

        public News News { get; set; }
    }
}
