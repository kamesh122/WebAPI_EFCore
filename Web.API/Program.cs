
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPI.Business;
using WebAPI.Business.Interfaces;
using WebAPI.Data.Context;
using WebAPI.Data.Repository;
using WebAPI.Data.Repository.Interfaces;
using WebAPI.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddDbContext<DatabaseContext>
    (options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection"));
        //options.UseLazyLoadingProxies();
    }

    );

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
