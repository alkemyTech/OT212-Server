namespace OngProject.Core.Models.DTOs
{
    public class SlideDTO
    {
        public string ImageUrl { get; set; }
        public int Order { get; set; }
    }

    public class SlideDetailsDto : SlideDTO
    {     
        public string Text { get; set; }
        public OrganizationDto Organization { get; set; }
    }
}
