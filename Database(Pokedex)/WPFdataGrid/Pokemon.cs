﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using System.Data.Entity;

namespace WPFdataGrid
{
    public class Pokemon : DbContext
    {
        public DbSet<PokemonBaseStat> PokemonBaseStats { get; set; }
        public DbSet<PokemonCapRate> PokemonCapRates { get; set; }

        public Pokemon() : base()
        {
            Database.SetInitializer<Pokemon>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonBaseStat>()
                .HasKey(e => e.PName);
            modelBuilder.Entity<PokemonCapRate>()
                .HasRequired(e => e.PokemonBaseStat);
        }

        public string GetFile()
        {
            return Database.Connection.DataSource;
        }
    }
}
