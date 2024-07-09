using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options=>{
    options.UseMySql(builder.Configuration.GetConnectionString("default"),new MySqlServerVersion(new Version(8, 0, 22)));
});

builder.Services.AddScoped<IStockRepository, StockRepository>();    //this is used for adding IStockRepository & StockRepository i.e interaces and repositories to the application.

var app = builder.Build();


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())

{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();                        //builder.services.AddControllers and app.MapControllers is necessary to put at the correct position in this file for mapping the controller here.
app.Run();