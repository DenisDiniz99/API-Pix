using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApi.ApiModels;
using WebApi.Data;
using WebApi.Models;
using WebApi.Utils;

namespace WebApi.Routes
{
    public static class PixRoutes
    {
        public static void Routes(this WebApplication app)
        {
            var routes = app.MapGroup("pix");

            routes.MapGet("", async(PixContext context) => 
            {
                var resp = await context.StaticPix.ToListAsync();

                if (resp == null)
                    return Results.NotFound();

                return Results.Ok(resp);
            });

            routes.MapGet("/key/{key}", async(string key, PixContext context) => 
            {
                var resp = await context.StaticPix.Where(x => x.Key == key).ToListAsync();

                if (resp == null    )
                    return Results.NotFound();

                return Results.Ok(resp);
            });

            routes.MapPost("", async(StaticPixRequest req, IValidator<StaticPix> validator, IMapper mapper, PixContext context) => 
            {
                var resp = mapper.Map<StaticPix>(req);

                var result = await validator.ValidateAsync(resp);

                if (!result.IsValid)
                    return Results.ValidationProblem(result.ToDictionary());
                
                var emv = PixTool.GeneratePix(resp);

                await context.AddAsync(resp);
                await context.SaveChangesAsync();

                return Results.Created("", emv);
            });
        }
    }
}