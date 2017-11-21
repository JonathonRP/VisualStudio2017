using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using System.Data.Entity;

namespace Database_Pokedex_
{
    public class Pokemon : DbContext
    {
        public DbSet<PokemonBaseStat> PokemonBaseStats { get; set; }

        public Pokemon() : base()
        {
            Database.SetInitializer<Pokemon>(null);
        }
    }
}
