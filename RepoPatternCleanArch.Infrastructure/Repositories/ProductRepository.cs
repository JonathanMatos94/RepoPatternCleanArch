using Microsoft.EntityFrameworkCore;
using RepoPatternCleanArch.Domain.Abstractions;
using RepoPatternCleanArch.Domain.Entities;
using RepoPatternCleanArch.Domain.Repositories;
using RepoPatternCleanArch.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternCleanArch.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(product, cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(Specification<Product> specification, CancellationToken cancellationToken)
        {
            var product = await context.Products
                .Where(specification.ToExpression())
                .FirstOrDefaultAsync(cancellationToken);

            return product;

        }
    }
}
