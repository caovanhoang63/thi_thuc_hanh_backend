using System.Diagnostics;

namespace test_mvc.Middlewares;

public class LoggerMiddleware
{
    private readonly RequestDelegate _next;

    public LoggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Ghi lại thời gian bắt đầu
        var stopwatch = Stopwatch.StartNew();

        // Ghi lại thông tin request
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

        // Gọi middleware tiếp theo trong pipeline
        await _next(context);

        // Ghi lại thời gian hoàn thành
        stopwatch.Stop();

        // Ghi lại thông tin response
        Console.WriteLine($"Response: {context.Response.StatusCode} - Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}