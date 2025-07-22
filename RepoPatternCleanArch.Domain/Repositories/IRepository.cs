using RepoPatternCleanArch.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternCleanArch.Domain.Repositories
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        
    }
}
