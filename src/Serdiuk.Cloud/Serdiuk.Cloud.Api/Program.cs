using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serdiuk.Cloud.Api.Data;
using Serdiuk.Cloud.Api.Infrastructure;
using Serdiuk.Cloud.Api.Infrastructure.Interfaces;
using Serdiuk.Cloud.Api.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var jwtConfig = new JwtConfig(builder.Configuration);

builder.Services.AddIdentity<IdentityUser, IdentityRole>(c =>
{
    c.SignIn.RequireConfirmedPhoneNumber = false;
    c.Password.RequireNonAlphanumeric = false;
    c.Password.RequiredLength = 5;
    c.Password.RequireUppercase = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
});

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(c =>
    {
        c.SaveToken = true;

        c.TokenValidationParameters = jwtConfig.GetTokenValidationParameters();
    });

builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
await DataInitializer.Intialize(app.Services.CreateScope().ServiceProvider);

app.Run();
