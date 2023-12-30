using YetDit.Application;
using YetDit.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => { options.AddPolicy("AllowAll", builder => builder.AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true).AllowAnyHeader()); });

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

//builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>)

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

app.UseAuthorization();

app.MapControllers();

app.Run();
