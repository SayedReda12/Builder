using Builder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.DAL.BuilderDbContext
{
    public class BuilderContext : DbContext
    {
        public BuilderContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Form> Forms { get; set; }

    }
}
