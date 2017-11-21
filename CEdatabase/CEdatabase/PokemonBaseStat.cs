using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Collections;

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
        [PokemonTypesAttribute(ValidTypes = new string[] {"Normal", "Bug", "Fighting", "Flying", "Ghost", "Ground", "Rock", "Steel", "Dark", "Dragon",
            "Electric", "Fire", "Grass", "Ice", "Psychic", "Water", "Fairy", ""}, ErrorMessage = "Not a valid pokemon type in Type1")]
        [Column(UpdateCheck = UpdateCheck.WhenChanged, CanBeNull = true)]
        public string Type1 { get; set; }
        [StringLength(10, ErrorMessage = "Only 10 characters allowed in Type2")]
        [PokemonTypesAttribute(ValidTypes = new string[] {"Normal", "Bug", "Fighting", "Flying", "Ghost", "Ground", "Rock", "Steel", "Dark", "Dragon",
            "Electric", "Fire", "Grass", "Ice", "Psychic", "Water", "Fairy", ""}, ErrorMessage = "Not a valid pokemon type in Type2")]
        [Column(UpdateCheck = UpdateCheck.WhenChanged, CanBeNull = true)]
        public string Type2 { get; set; }
    }

    /// <summary>
    /// Define an attribute that validate a property againts a white list
    /// Note that currently it only supports int type
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    sealed public class PokemonTypesAttributeAttribute : ValidationAttribute
    {
        /// <summary>
        /// The White List 
        /// </summary>
        public string[] ValidTypes { get; set; }

        /// <summary>
        /// Validation occurs here
        /// </summary>
        /// <param name="value">Value to be validate</param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            else
            {
                return ValidTypes.Contains(value.ToString());
            }
        }
    }
}
