using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Application Services
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IAuthService, PawlyPetCare.Application.Services.AuthService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IProductService, PawlyPetCare.Application.Services.ProductService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IDoctorService, PawlyPetCare.Application.Services.DoctorService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IPetService, PawlyPetCare.Application.Services.PetService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IBlogService, PawlyPetCare.Application.Services.BlogService>();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173") // Adjust port if needed
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
