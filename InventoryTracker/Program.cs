using Microsoft.EntityFrameworkCore;
using InventoryTracker.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<InventoryContext>(opt =>
        opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Initial Catalog=InventoryDB; Integrated Security=true;")
        );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();