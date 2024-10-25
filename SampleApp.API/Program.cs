using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SampleApp.API.Data;
using SampleApp.API.Interfaces;
using SampleApp.API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using SampleApp.API.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<SampleAppContext>();
builder.Services.AddCors();
builder.Services.AddAuthorization();
builder.Services.AddJwtServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

 
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader());

app.MapControllers();


app.Run();


