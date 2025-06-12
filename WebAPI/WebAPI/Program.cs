using WebAPI.Services;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IFilmService, FilmService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(corsBuilder =>
    corsBuilder.AddPolicy("politykaCORS",
        policyBuilder => policyBuilder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("politykaCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
