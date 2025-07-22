using MediatR;
using RepoPatternCleanArch.Domain.Abstractions;
using RepoPatternCleanArch.Domain.Repositories;
using RepoPatternCleanArch.Domain.Specifications.Products;

namespace RepoPatternCleanArch.Application.UseCases.Products.GetById
{
    //Utilizando pacote MediatR
    //Manipulador de comandos
    public sealed class Handler(IProductRepository repository) : IRequestHandler<Command, Result<Response>>
    {
        public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            var spec = new GetProductByIdSpecification(request.Id);
            var product = await repository.GetByIdAsync(spec, cancellationToken);

            return product is null
                ? Result.Failure<Response>(new Error("404", "Product not Found"))
                : Result.Success(new Response(product.Id, product.Name));
        }
    }
}
