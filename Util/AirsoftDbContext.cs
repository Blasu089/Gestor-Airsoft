﻿using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Modelos.EntityType;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace ApiAirsoft.Util
{
    public class AirsoftDbContext : DbContext
    {
        public DbSet<Arma> Armas { get; set; }
        public DbSet<Color> Colores { get; set; }

        public AirsoftDbContext(DbContextOptions<AirsoftDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            callCreating(modelBuilder);
        }

        private void callCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArmaEntityTypeConfiguration).Assembly);
        }
    }
}
