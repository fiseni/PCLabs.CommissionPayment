using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PCLabs.CommissionPayment.Domain.Contracts;
using PCLabs.CommissionPayment.Infrastructure;
using PCLabs.CommissionPayment.Infrastructure.Blogs;
using PCLabs.SharedKernel.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.EnableAnnotations();
});
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConnection")));
builder.Services.AddScoped<AppDbInitializer>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
builder.Services.AddScoped<IBlogRepository, BlogRepositoryEFCore>();
//builder.Services.AddScoped<IBlogRepository, BlogRepositoryDapper>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblyContaining<Program>();
    options.ImplicitlyValidateRootCollectionElements = true;
});

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

// Seed Database
using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<AppDbInitializer>();
    await dbInitializer.Initialize();
}

app.Run();
