using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ActivityBusiness : IActivityBusiness
    {
        private UnitOfWork _unitOfWork;

        public ActivityBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        public Task<List<Activity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Activity> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Insert(ActivityInsertDto entity)
        {
            var activity = entity.ToActivityModel();
            activity.Image = await Helper.ImageUploadHelper.UploadImageToS3(entity.Image);

            await _unitOfWork.ActivityRepository.InsertAsync(activity);
            await _unitOfWork.SaveAsync();
        }

        public Task Update(Activity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
