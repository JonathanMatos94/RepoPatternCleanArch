using MediatR;
using RepoPatternCleanArch.Domain.Abstractions;
using RepoPatternCleanArch.Domain.Entities;
using RepoPatternCleanArch.Domain.Repositories;

namespace RepoPatternCleanArch.Application.UseCases.Products.Create
{
    public sealed class Handler(IProductRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<Command, Result<Response>>
    {
        public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };

            await repository.CreateAsync(product, cancellationToken);
            await unitOfWork.CommitAsync();

            return Result.Success(new Response("Produto criado com sucesso!"));
        }
    }
}
