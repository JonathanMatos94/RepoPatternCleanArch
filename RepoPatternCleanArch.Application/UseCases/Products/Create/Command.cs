using MediatR;
using RepoPatternCleanArch.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternCleanArch.Application.UseCases.Products.Create
{
    public sealed record Command(string Name) : IRequest<Result<Response>>
    {
    }
}
