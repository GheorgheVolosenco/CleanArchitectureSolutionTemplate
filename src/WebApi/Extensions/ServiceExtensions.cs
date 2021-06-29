using CarDataPlatformIngestor.Application.DTOs.Product.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using WebApi.ActionFilters;

namespace CarDataPlatformIngestor.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddFluentValidationRulesScoped();

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clean Architecture API",
                    Description = "API Description.",
                    Contact = new OpenApiContact
                    {
                        Name = "Contact name",
                        Email = "john.doe@mail.com",
                        Url = new Uri("https://google.com"),
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });

                // Add Controller's summaries descriptions
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void AddControllersWithFluentValidations(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            }).AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining(typeof(CreateProductRequestValidator));
            });
        }

        public static void AllowAnyOrigin(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("CORSPolicy",
                    options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static void AllowSelectedOrigins(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(o => o.AddPolicy("CORSPolicy", builder =>
            {
                var origins = configuration["CorsOrigins"].Split(",");
                builder.WithOrigins(origins).AllowCredentials().AllowAnyHeader().AllowAnyMethod();
            }));
        }
    }
}
