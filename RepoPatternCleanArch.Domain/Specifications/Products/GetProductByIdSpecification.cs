using RepoPatternCleanArch.Domain.Abstractions;
using RepoPatternCleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternCleanArch.Domain.Specifications.Products
{
    public class GetProductByIdSpecification(Guid id) : Specification<Product>
    {
        public override Expression<Func<Product, bool>> ToExpression()
            => product => product.Id == id;
         
    }
}
