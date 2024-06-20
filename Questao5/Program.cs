using Questao5.Application;
using Questao5.Infrastructure;
using Questao5.Infrastructure.Sqlite;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.ConfigureSwagger();

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

app.Services.GetService<IDatabaseBootstrap>().Setup();

app.Run();
