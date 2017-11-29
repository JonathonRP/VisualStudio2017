using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace WPFdataGrid
{
    [Table(Name = "PokemonCapRates")]
    public class PokemonCapRate
    {
        [Required(ErrorMessage = "Pokemon name is required to save")]
        [StringLength(15, ErrorMessage = "Only 15 characters allowed in pokemon name")]
        [Column(IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never, CanBeNull = false)]
        [Key]
        public string PName { get; set; }
        [Column]
        public Int16 CapRate { get; set; }
        [Column]
        public Int16 ExpDrop { get; set; }

        public virtual PokemonBaseStat PokemonBaseStat { get; set; }
    }
}
