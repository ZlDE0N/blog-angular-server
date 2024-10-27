using BackendBlogServicesApi.Data;
using BackendBlogServicesApi.Repositories.Interfaces;
using BackendBlogServicesApi.Repositories;
using BackendBlogServicesApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://localhost:5001", "https://localhost:5002");
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:4200")  
                        .AllowAnyHeader()                      
                        .AllowAnyMethod()                      
                        .AllowCredentials()                    
                        .WithExposedHeaders("Custom-Header")   
                        .SetPreflightMaxAge(TimeSpan.FromMinutes(10))
    );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar el repositorio y el servicio
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryService>();

// Registrar el repositorio y el servicio
builder.Services.AddScoped<IEntriesBlogRepository, EntriesBlogRepository>();
builder.Services.AddScoped<EntriesBlogService>();

// Registrar el repositorio y el servicio
builder.Services.AddScoped<IEntriesBlogCategoryRepository, EntriesBlogCategoryRepository>();
builder.Services.AddScoped<EntriesBlogCategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowFrontend");

app.Run();
