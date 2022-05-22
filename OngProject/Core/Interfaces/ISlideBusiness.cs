using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Interfaces
{
    public interface ISlideBusiness
    {
        public IEnumerable<Slide> GetAllSlides();

        public Slide GetSlide(int id);

        public void InsertSlide(Slide slide);

        public void UpdateSlide(int id, Slide slide);

        public void DeleteSlide(int id);
    }
}
