using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Database_Pokedex_
{
    [Table(Name = "PokemonCapRates")]
    public class PokemonCapRate
    {
        [Column(IsPrimaryKey = true)]
        public string PName { get; set; }
        [Column]
        public int CapRate { get; set; }
        [Column]
        public int ExpDrop { get; set; }
    }
}
