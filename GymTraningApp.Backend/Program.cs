using GymApp.Configurations;
using GymApp.Database;
using GymApp.Identity;
using GymApp.services;
using GymApp.Services;
using GymTraningApp.Identity;
using GymTraningApp.Models.Identity;
using GymTraningApp.services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors( Options => {
    Options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod()
    );
});

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("developmentDatabase");
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IUserLoginService, LoginService>();
builder.Services.AddScoped<IUserRegisterService, UserRegisterService>();

builder.Services.AddScoped<ICurrentUserService, CurrentUser>();
builder.Services.AddScoped<ICurrentSession, CurrentSession>();

builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IGymSessionRepository, GymSessionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
