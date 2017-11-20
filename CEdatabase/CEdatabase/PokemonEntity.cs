using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.OleDb;
using System.Data.Entity;
using System.Data;

namespace Database_Pokedex_
{
    class PokemonEntity : DbContext
    {
        public DbSet<PokemonBaseStat> PokemonBaseStats { get; set; }

        public PokemonEntity() : base()
        {
            Database.SetInitializer<PokemonEntity>(null);
        }
    }
}
