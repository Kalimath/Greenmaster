using System.Net;

namespace eu.mbdevelopment.greenmaster.Api.GardenStyling.Base;

public class Response<T> : IResponse<T>
{
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; }
    public string[] Errors { get; set; }
    public T Data { get; set; }


    public Response() { }
    public Response(T data)  { }
    public Response(HttpStatusCode statusCode, T data) : this(statusCode, default, default, data) { }
    public Response(HttpStatusCode statusCode, T data, string message): this(statusCode, message, default, data) { }
    public Response(HttpStatusCode statusCode, string message, string[] errors) : this(statusCode, message, errors, default) { }
    public Response(HttpStatusCode statusCode, string errormessage) : this(statusCode, errormessage, default,default) { }

    public Response(HttpStatusCode status, string message, string[] errors, T data)
    {
        Status = status;
        Message = message;
        Errors = errors;
        Data = data;
    }
}

public interface IResponse<T>
{
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; }
    public string[] Errors { get; set; }
    public T Data { get; set; }
}
