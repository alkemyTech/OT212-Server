using System;

namespace OngProject.Core.Models
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, bool succeeded = true, string[] errors = null, string message = "Success")
        {
            Data = data;
            Succeeded = succeeded;
            Errors = errors;
            Message = message;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}

public static class ResponseMessage
{
    public static string Success = "Success";
    public static string Error = "Error";
    public static string NotFound = "Record not found";
    public static string ValidationErrors = "Validations errors found";
}
