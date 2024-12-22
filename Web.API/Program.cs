
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business;
using WebAPI.Business.Interfaces;
using WebAPI.Data.Context;
using WebAPI.Data.Repository;
using WebAPI.Data.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Host.ConfigureAppConfiguration((context, config) =>
{
    var settings = config.Build();
    var keyVaultURL = settings["KeyVaultConfiguration:KeyVaultURL"];
    var keyVaultTenanetId = settings["KeyVaultConfiguration:TenanetId"];
    var keyVaultClientId = settings["KeyVaultConfiguration:ClientId"];
    var keyVaultClientSecret = settings["KeyVaultConfiguration:ClientSecret"];
    var credentials = new ClientSecretCredential(keyVaultTenanetId, keyVaultClientId, keyVaultClientSecret);
    var client = new SecretClient(new Uri(keyVaultURL), credentials);
    config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
});

builder.Services.AddDbContext<DatabaseContext>
    (options =>
    {
        options.UseSqlServer(builder.Configuration["connectionstring"]);
        // options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection"));
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
