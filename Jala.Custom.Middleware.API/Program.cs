using System.Reflection.Metadata.Ecma335;
using Jala.Custom.Middleware.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

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



app.UseHttpsRedirection();

app.UseParamsMiddleware();

app.UseMiddleware<QueryMiddleware>();

app.UseAuthorization();
// app.Use(async (context, next) =>
// {
//     Console.WriteLine("Log");
//     await context.Response.WriteAsync("The end");
//     return;
//     await next.Invoke(context);
//     Console.WriteLine("Log");
// });

app.MapControllers();

// app.Run(async context =>
// {
//     await context.Response.WriteAsync("The end");
// });

app.Run();
