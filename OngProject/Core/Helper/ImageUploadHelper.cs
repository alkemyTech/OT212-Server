using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public static class ImageUploadHelper
    {   
        /* This is the main method for uploading an image*/

        public static async Task<string> UploadImageToS3(IFormFile file)
        {
            var isImage = GetKnownFileType(await GetBytes(file));

            if (!(isImage.Equals(FileType.Jpeg) ||
                isImage.Equals(FileType.Bmp) ||
                isImage.Equals(FileType.Png) ||
                isImage.Equals(FileType.Gif)))
            {
                throw new Exception("Not a jpg/png/bmp/gif image");
            }

            var client = new AmazonS3Client(RegionEndpoint.USEast1);
            var newMemoryStream = new MemoryStream();
            file.CopyTo(newMemoryStream);
            string bucketName = "cohorte-mayo-2820e45d";
            string key = "images/" + file.FileName;

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = newMemoryStream,
                Key = key,
                BucketName = bucketName,
            };

            var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.UploadAsync(uploadRequest);

            string uploadedFileUrl = client.GetPreSignedURL(new GetPreSignedUrlRequest()
            {
                BucketName = bucketName,
                Key = key,
                Expires = DateTime.Now.AddHours(4) // Appropiate duration
            });

            return uploadedFileUrl.ToString();
        }

        /* Below methods are for checking if the file is a .jpg/.png/.bmp./.gif image */

        public enum FileType
        {
            Unknown,
            Jpeg,
            Bmp,
            Gif,
            Png,
        }

        private static readonly Dictionary<FileType, byte[]> KNOWN_FILE_HEADERS = new Dictionary<FileType, byte[]>()
        {
            { FileType.Jpeg, new byte[]{ 0xFF, 0xD8 }}, // JPEG
		    { FileType.Bmp, new byte[]{ 0x42, 0x4D }}, // BMP
		    { FileType.Gif, new byte[]{ 0x47, 0x49, 0x46 }}, // GIF
		    { FileType.Png, new byte[]{ 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }}, // PNG
	    };

        public static FileType GetKnownFileType(ReadOnlySpan<byte> data)
        {
            foreach (var check in KNOWN_FILE_HEADERS)
            {
                if (data.Length >= check.Value.Length)
                {
                    var slice = data.Slice(0, check.Value.Length);
                    if (slice.SequenceEqual(check.Value))
                    {
                        return check.Key;
                    }
                }
            }

            return FileType.Unknown;
        }
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
