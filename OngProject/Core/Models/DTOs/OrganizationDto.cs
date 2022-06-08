using System.Collections.Generic;

namespace OngProject.Core.Models.DTOs
{
    public class OrganizationDto : Dto
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string FacebookUrl { get; set; }

        public string LinkedinUrl { get; set; }

        public string InstagramUrl { get; set; }
    }

    public class OrganizationDetailsDto : OrganizationDto
    {
        public IEnumerable<SlideDTO> Slides { get; set; }
    }
}
