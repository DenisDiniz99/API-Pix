using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

builder.UseServices();