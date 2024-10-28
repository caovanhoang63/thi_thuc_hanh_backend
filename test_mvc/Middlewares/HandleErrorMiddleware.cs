using System.Net;

namespace test_mvc.Middlewares;

public class HandleErrorMiddleware
{
    private readonly RequestDelegate _next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            // await HandleExceptionAsync(context, ex);
        }
    }

    // private Task HandleExceptionAsync(HttpContext context, Exception ex)
    // {
    //     context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    //
    //     var response = new
    //     {
    //         StatusCode = context.Response.StatusCode,
    //         Message = "An unexpected error occurred.",
    //         Detailed = ex.Message // Chỉ nên trả về thông tin chi tiết trong môi trường phát triển
    //     };
    //
    //     var jsonResponse = JsonConvert.SerializeObject(response);
    //     context.Response.ContentType = "application/json";
    //     return context.Response.WriteAsync(jsonResponse);
    // }
}