using Authentication.Api.Infrastructure.Configurations;
using Authentication.Api.Infrastructure.Middlewares;
using Authentication.BusinessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppSettings();
builder.AddJWTWorkerSettings();

builder.Services.AddAuthService();
builder.Services.AddUserService();

var settings = builder.Configuration.GetSection("JWTWorkerSettings");
var audience = settings.GetValue<string>("Audience");
var issuer = settings.GetValue<string>("Issuer");
var key = settings.GetValue<string>("Key");

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidAudience = audience,
        ValidIssuer = issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ValidateAudience = true
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseMiddleware<JWTMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


namespace Authentication
{
    public partial class Program { }
}