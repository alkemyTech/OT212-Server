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

        public static ActivityDto ToActivityDto(this ActivityInsertDto activityInsertDto)
        {
            ActivityDto activityDto = new ActivityDto();

            activityDto.Name = activityInsertDto.Name;
            activityDto.Content = activityInsertDto.Content;
            activityDto.Image = activityInsertDto.Image?.FileName;

            return activityDto;
        }

        public static ActivityDto ToActivityDto(this Activity activity)
        {
            ActivityDto activityDto = new ActivityDto();

            activityDto.Id = activity.Id;
            activityDto.Name = activity.Name;
            activityDto.Content = activity.Content;
            activityDto.Image = activity.Image;

            return activityDto;
        }
    }
}
