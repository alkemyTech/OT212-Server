using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public class SlideBusiness : ISlideBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public SlideBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteSlide(int id)
        {
            Slide slide = _unitOfWork.SlideRepository.GetById(id);
            _unitOfWork.SlideRepository.Delete(slide);
            _unitOfWork.Save();
        }

        public IEnumerable<Slide> GetAllSlides()
        {
            return _unitOfWork.SlideRepository.GetAll();
        }

        public Slide GetSlide(int id)
        {
            return _unitOfWork.SlideRepository.GetById(id);
        }

        public void InsertSlide(Slide slide)
        {
            _unitOfWork.SlideRepository.Insert(slide);
            _unitOfWork.Save();
        }

        public void UpdateSlide(Slide slide)
        {
            _unitOfWork.SlideRepository.Update(slide);
            _unitOfWork.Save();
        }
    }
}
