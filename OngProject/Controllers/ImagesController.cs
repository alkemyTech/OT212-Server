using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> UploadFileToS3(IFormFile file)
        {
            try
            {
                var client = new AmazonS3Client(RegionEndpoint.USEast1);
                var newMemoryStream = new MemoryStream();
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = newMemoryStream,
                    Key = file.FileName,
                    BucketName = "cohorte-mayo-2820e45d"
                };
                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(uploadRequest);

                return Ok("https://cohorte-mayo-2820e45d.s3.us-east-1.amazonaws.com/" + file.FileName.ToString());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}
