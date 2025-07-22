using MediatR;
using RepoPatternCleanArch.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternCleanArch.Application.UseCases.Products.GetById
{
    //Saída
    public sealed record Response(Guid Id, string Name);
}
