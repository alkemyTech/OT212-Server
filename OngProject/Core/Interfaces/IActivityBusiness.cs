using System.Collections.Generic;
using System.Diagnostics;

namespace OngProject.Core.Interfaces
{
    public interface IActivityBusiness
    {
        public IEnumerable<Activity> GetAllActivities();

        public Activity GetActivity(int id);

        public void InsertActivity(Activity activity);

        public void UpdateActivity(int id, Activity activity);

        public void DeleteActivity(int id);
    }
}
