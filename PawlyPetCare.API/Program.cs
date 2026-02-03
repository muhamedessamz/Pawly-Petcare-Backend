using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Application Services
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IAuthService, PawlyPetCare.Application.Services.AuthService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IDoctorService, PawlyPetCare.Application.Services.DoctorService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IPetService, PawlyPetCare.Application.Services.PetService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IBlogService, PawlyPetCare.Application.Services.BlogService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IUserService, PawlyPetCare.Application.Services.UserService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IAppointmentService, PawlyPetCare.Application.Services.AppointmentService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IOrderService, PawlyPetCare.Application.Services.OrderService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IAdminService, PawlyPetCare.Application.Services.AdminService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IProductService, PawlyPetCare.Application.Services.ProductService>();
builder.Services.AddScoped<PawlyPetCare.Application.Interfaces.IVolunteerService, PawlyPetCare.Application.Services.VolunteerService>();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173", 
                               "http://localhost:5174", "http://127.0.0.1:5174")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Auto-migrate database on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseStaticFiles(); // For uploaded images


app.UseAuthorization();

app.MapControllers();

app.Run();
