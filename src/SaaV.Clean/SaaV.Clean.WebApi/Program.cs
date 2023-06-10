using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SaaV.Clean.Application.Dummies.Handlers;
using SaaV.Clean.WebApi.Dummies;
using SaaV.Clean.WebApi.Extensions;
using SaaV.Clean.WebApi.Middlewares;
using SaaV.Clean.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add database context to the container.
builder.Services.AddDbContext<CleanDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CleanConnectionString")));

// Add services to the container.           
builder.Services.AddJwtAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<CreateDummyHandler>());
builder.Services.AddValidatorsFromAssemblyContaining<CreateDummyValidator>();

builder.Services.AddProviders();
builder.Services.AddRepositories();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapDummyEndpoints();
app.MapAuthenticationEndpoints();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
