using MediatR;
using Microsoft.EntityFrameworkCore;
using RepoPatternCleanArch.Application;
using RepoPatternCleanArch.Infrastructure;
using RepoPatternCleanArch.Infrastructure.Data;

namespace RepoPatternCleanArch.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(connectionString, b => b.MigrationsAssembly("RepoPatternCleanArch.Api"));
            });

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();


            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapPost("/v1/products", async(
                ISender sender,
                RepoPatternCleanArch.Application.UseCases.Products.Create.Command command,
                CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : Results.BadRequest(result.Error);
            });

            app.MapGet("/v1/products/{id}", async (
                ISender sender, //Utiliza o handler criado
                Guid id,
                CancellationToken cancellationToken) =>
            {
                var command = new RepoPatternCleanArch.Application.UseCases.Products.GetById.Command(id);
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.BadRequest(result.Error);
            });

            app.Run();
        }
    }
}
