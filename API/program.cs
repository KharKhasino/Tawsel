using Microsoft.EntityFrameworkCore;
using Shipping.API.Data;
using Shipping.API.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SQL_Conn")));

builder.Services.AddCors(options => options.AddPolicy("default", policy =>
policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

builder.Services.AddScoped<IGovernRepo, GovernRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("default");

app.UseAuthorization();

app.MapControllers();

app.Run();
