using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(options=>options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<ITrainerService,TrainerService>();
builder.Services.AddScoped<IClientService,ClientService>();
builder.Services.AddScoped<IWorkoutService,WorkoutService>();
builder.Services.AddScoped<IWorkoutSessionService,WorkoutSessionService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "ok"));
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
