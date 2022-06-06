using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class ValidateAsImage : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var formFile = value as IFormFile;

            if (formFile == null)
                return ValidationResult.Success;

            bool result = false;

            var task = Task.Run(async () => { 
                result = await ImageUploadHelper.IsImage(formFile); 
            });

            task.Wait();

            if(result)
                return ValidationResult.Success;

            return new ValidationResult("The file isn't a valid image.");
        }
    }
}
