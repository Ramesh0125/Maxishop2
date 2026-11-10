using AdoNetApi.IService;
using AdoNetApi.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shan.Api.Data;

var builder = WebApplication.CreateBuilder(args);


// >>>> Entity Framework <<<<

// Add services to the container.

//#region Database Connectivity

//builder.Services
//    .AddDbContext<ApplicationDbcontext>(options=> 
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//#endregion


builder.Services.AddControllers();

// Register Interface and Service

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
app.Run();
