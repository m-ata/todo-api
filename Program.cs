using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("Todos"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("TodoAppOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("TodoAppOrigin");

app.UseRouting();

app.MapControllerRoute(
    name: "TodoApi",
    pattern: "api/{controller}/{action}/{id?}",
    defaults: new { controller = "Todo", action = "GetTodos" }
    );

app.UseAuthorization();

app.MapControllers();

app.Run();