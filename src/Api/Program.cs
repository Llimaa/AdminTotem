

using Application.AggregatesModel.ServiceAggregate;
using Application.AggregatesModel.ServiceDeskAggregate;
using Application.AggregatesModel.TotemAggregate;
using Application.AggregatesModel.UserAggregate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TotemHandler>();
builder.Services.AddScoped<ServiceHandler>();
builder.Services.AddScoped<UserHandler>();
builder.Services.AddScoped<ServiceDeskHandler>();
builder.Services.AddScoped<ITotemQueries, TotemQueries>();
builder.Services.AddAdminDependencies(builder.Configuration);

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
