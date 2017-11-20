using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;

namespace Database_Pokedex_
{
    public class Pokemon : DataContext
    {
        public Table<PokemonBaseStat> PokemonBaseStats { get; set; }
        public Table<PokemonCapRate> PokemonCapRates { get; set; }

        public Pokemon (IDbConnection connection) : base (connection)
        {
            PokemonBaseStats = GetTable<PokemonBaseStat>();
            PokemonCapRates = GetTable<PokemonCapRate>();
        }
    }
}
