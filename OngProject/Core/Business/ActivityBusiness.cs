using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
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

        public async Task<ActivityDto> Insert(ActivityInsertDto entity)
        {
            var activity = entity.ToActivityModel();
            activity.Image = await Helper.ImageUploadHelper.UploadImageToS3(entity.Image);

            await _unitOfWork.ActivityRepository.InsertAsync(activity);
            await _unitOfWork.SaveAsync();

            return activity.ToActivityDto();
        }

        public async Task<Response<ActivityDto>> Update(ActivityUpdateDto updateDto, int id)
        {
            try
            {
                var activity = await _unitOfWork.ActivityRepository.GetByIdAsync(id);

                if(activity == null)
                    return new Response<ActivityDto>
                    {
                        Succeeded = false,
                        Message = ResponseMessage.NotFound,
                        Errors = new string[] {"Can't find the activity.'"}
                    };

                if (updateDto.Image != null)
                { 
                    var imgUrl = await Helper.ImageUploadHelper.UploadImageToS3(updateDto.Image);

                    if(string.IsNullOrEmpty(imgUrl))
                        return new Response<ActivityDto>
                        {
                            Succeeded = false,
                            Message = ResponseMessage.Error,
                            Errors = new string[] { "Can't update image." }
                        };

                    activity.Image = imgUrl;
                }

                activity.Name = updateDto.Name;
                activity.Content = updateDto.Content;

                await _unitOfWork.ActivityRepository.UpdateAsync(activity);
                await _unitOfWork.SaveAsync();

                var activityDto = activity.ToActivityDto();

                return new Response<ActivityDto> {
                    Data = activityDto,
                    Succeeded = true,
                    Message = ResponseMessage.Success,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"ActivityBusiness.Update: {ex.Message}");
                return new Response<ActivityDto> { 
                    Succeeded = false,
                    Message = ResponseMessage.UnexpectedErrors,
                    Errors = new string[] {"Unexpected error when try to update activity."}
                };
            }
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
