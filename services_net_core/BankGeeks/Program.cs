using BankGeeks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var connectionString = builder.Configuration.
                       GetConnectionString("BankGeeks");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CalculatorContext>(opt=>
    opt.UseSqlServer(connectionString)
);
builder.Services.AddCors(opt => {
    opt.AddPolicy(name: MyAllowSpecificOrigins, builder => { 
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    }
        );
});
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
