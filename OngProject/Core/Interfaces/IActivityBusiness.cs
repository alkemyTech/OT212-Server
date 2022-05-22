using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Interfaces
{
    public interface IActivityBusiness
    {
        public IEnumerable<Activity> GetAllActivities();

        public Activity GetActivity(int id);

        public void InsertActivity(Activity activity);

        public void UpdateActivity(Activity activity);

        public void DeleteActivity(int id);
    }
}
