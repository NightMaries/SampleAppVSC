using SampleApp.API.Interfaces;
using SampleApp.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IRoleRepository, RoleRepository>();
builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader());

app.UseHttpsRedirection();
app.MapControllers();


app.Run();


