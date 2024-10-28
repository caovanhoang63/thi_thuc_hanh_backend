using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_mvc.Config;
using test_mvc.Mappings;
using test_mvc.Middlewares;
using test_mvc.Repositories.EF;
using test_mvc.Repositories.Interfaces;
using test_mvc.Services.Implementation;
using test_mvc.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.env.json", optional: true, reloadOnChange: true);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AppMappingProfile));


// Dependency Injection
builder.Services.AddScoped<IProductRepository, ProductEFRepo>();
builder.Services.AddScoped<IUserRepository,UserEFRepo>();
builder.Services.AddScoped<ICategoryRepository, CategoryEFRepo>();


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

// Controller Configuration
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    })
    .AddXmlSerializerFormatters()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressConsumesConstraintForFormFileParameters = true;
        options.SuppressInferBindingSourcesForParameters = true;
        // Thêm custom validation response
        options.InvalidModelStateResponseFactory = context =>
        {
            var result = new BadRequestObjectResult(context.ModelState);
            result.ContentTypes.Add("application/json");
            return result;
        };
    });

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Routing Configuration
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
    options.AppendTrailingSlash = false;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();

builder.Services.AddResponseCompression();

var app = builder.Build();

// app.UseMiddleware<ErrorEventHandler>();
app.UseMiddleware<LoggerMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

// Response Compression
app.UseResponseCompression();

// Map controllers
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();