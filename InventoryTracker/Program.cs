using Microsoft.EntityFrameworkCore;
using InventoryTracker.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddDbContext<InventoryContext>(opt =>
        opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Initial Catalog=InventoryDB; Integrated Security=true;")
        );
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();