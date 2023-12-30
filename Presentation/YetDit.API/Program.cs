using FluentValidation.AspNetCore;
using YetDit.API.Extensions;
using YetDit.Application;
using YetDit.Application.Validators.Comments;
using YetDit.Application.Validators.Posts;
using YetDit.Infrastructure.Filters;
using YetDit.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => { options.AddPolicy("AllowAll", builder => builder.AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true).AllowAnyHeader()); });

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration =>
    {
        configuration.RegisterValidatorsFromAssemblyContaining<CreateCommentValidator>();
        configuration.RegisterValidatorsFromAssemblyContaining<CreatePostValidator>();
    }).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);



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

app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILogger<Program>>());

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
