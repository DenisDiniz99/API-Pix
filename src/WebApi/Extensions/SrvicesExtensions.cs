using FluentValidation;
using Microsoft.OpenApi.Models;
using WebApi.Data;
using WebApi.Mappings;
using WebApi.Models;
using WebApi.Routes;
using WebApi.Validations;

namespace WebApi.Extensions
{
    public static class SrvicesExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de Pix",
                    Version = "v1",
                    Description = "API para a geração de Pix estático.",
                    Contact = new OpenApiContact() 
                    {
                        Name = "Denis Diniz", 
                        Email = "denisdiniz99@gmail.com"
                    }
                });
            });
            builder.Services.AddScoped<PixContext>();
            builder.Services.AddScoped<IValidator<StaticPix>, PixValidator>();
            builder.Services.AddAutoMapper(typeof(PixMapper));
        }

        public static void UseServices(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.Routes();

            app.Run();
        }
    }
}