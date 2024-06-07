using Application;
using Application.Abstract.Filters;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Storages.Local;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using Serilog;
using Serilog.Core;
using System.Text;
using API.Extensions;
using Domain.Entities;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers(opt => opt.Filters.Add<ValidationFilter>()).AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssemblyContaining<ValidationFilter>();
}).ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true)
.AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
#pragma warning restore CS0618 // Type or member is obsolete

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddStorage<LocalStorage>();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("http://localhost:4200", "https://localhost:7119")
    .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OmarElhadyDentalClinc", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            }, new string[] {}
        }
    });
});

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]!))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigurationExceptionHandler();

app.UseStaticFiles();

app.UseHttpLogging();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.ConfigurationUseLogger();

app.MapControllers();

app.Run();
