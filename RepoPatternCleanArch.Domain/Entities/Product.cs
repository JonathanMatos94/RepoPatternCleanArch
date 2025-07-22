using RepoPatternCleanArch.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternCleanArch.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;
    }
}
