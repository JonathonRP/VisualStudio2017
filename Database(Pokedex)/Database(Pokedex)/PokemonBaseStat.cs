using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace Database_Pokedex_
{
    [Table(Name = "PokemonBaseStats")]
    public partial class PokemonBaseStat
    {
        [Required(ErrorMessage = "Pokemon name is required to save")]
        [StringLength(15, ErrorMessage = "Only 15 characters allowed in pokemon name")]
        [Column(IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never, CanBeNull = false)]
        [Key]
        public string PName { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public Int16 HP { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public Int16 Attack { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public Int16 Defense { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public Int16 SPAttack { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public Int16 SPDefense { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public Int16 Speed { get; set; }
        [StringLength(10, ErrorMessage = "Only 10 characters allowed in Type1")]
        //[RegularExpression("Normal" || "Bug" || "Fighting" || "Flying" || "Ghost" || "Ground" || "Rock" || "Steel" || "Dark" || "Dragon" || 
        //                        "Electric" || "Fire" || "Grass" || "Ice" || "Psychic" || "Water" || "Fairy", ErrorMessage = "Must enter a valid pokemon type")]
        [Column(UpdateCheck = UpdateCheck.WhenChanged, CanBeNull = true)]
        public string Type1 { get; set; }
        [StringLength(10, ErrorMessage = "Only 10 characters allowed in Type2")]
        //[RegularExpression(@"Normal Or Bug Or Fighting Or Flying Or Ghost Or Ground Or Rock Or Steel Or Dark Or Dragon Or 
        //                        Electric Or Fire Or Grass Or Ice Or Psychic Or Water Or Fairy", ErrorMessage = "Must enter a valid pokemon type")]
        [Column(UpdateCheck = UpdateCheck.WhenChanged, CanBeNull = true)]
        public string Type2 { get; set; }
    }
}
