using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Panaderia_EntityFramework.Models;

namespace Panaderia_EntityFramework
{
    public class EntityFrameworkIntroContext : DbContext
    {
        public EntityFrameworkIntroContext (DbContextOptions<EntityFrameworkIntroContext> options)
            : base(options)
        {
        }

        public DbSet<Panaderia_EntityFramework.Models.Panaderia> Panaderia { get; set; } = default!;
    }
}
