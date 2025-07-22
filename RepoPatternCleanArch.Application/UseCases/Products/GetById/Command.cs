using MediatR;
using RepoPatternCleanArch.Domain.Abstractions;

namespace RepoPatternCleanArch.Application.UseCases.Products.GetById
{
    //Entrada
    public sealed record Command(Guid Id) : IRequest<Result<Response>>;
}
