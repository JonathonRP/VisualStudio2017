using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Database_Pokedex_
{
    [Table(Name = "PokemonBaseStats")]
    public class PokemonBaseStat
    {
        [Column(IsPrimaryKey = true)]
        public string PName { get; set; }
        [Column]
        public Int16 HP { get; set; }
        [Column]
        public Int16 Attack { get; set; }
        [Column]
        public Int16 Defense { get; set; }
        [Column]
        public Int16 SPAttack { get; set; }
        [Column]
        public Int16 SPDefense { get; set; }
        [Column]
        public Int16 Speed { get; set; }
        [Column]
        public string Type1 { get; set; }
        [Column]
        public string Type2 { get; set; }
    }
}
