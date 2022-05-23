using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public class ActivityBusiness : IActivityBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public ActivityBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteActivity(int id)
        {
            Activity activity = _unitOfWork.ActivityRepository.GetById(id);
            _unitOfWork.ActivityRepository.Delete(activity);
            _unitOfWork.Save();
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            return _unitOfWork.ActivityRepository.GetAll();
        }

        public Activity GetActivity(int id)
        {
            return _unitOfWork.ActivityRepository.GetById(id);
        }

        public void InsertActivity(Activity activity)
        {
            _unitOfWork.ActivityRepository.Insert(activity);
            _unitOfWork.Save();
        }

        public void UpdateActivity(Activity activity)
        {
            _unitOfWork.ActivityRepository.Update(activity);
            _unitOfWork.Save();
        }
    }
}
