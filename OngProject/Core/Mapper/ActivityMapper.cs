using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class ActivityMapper
    {
        public static Activity ToActivityModel(this ActivityInsertDto activityDto)
        {
            Activity activity = new Activity();

            activity.Name = activityDto.Name;
            activity.Content = activityDto.Content;
            activity.Image = activityDto.Image?.FileName;
            
            return activity;
        }
    }
}
