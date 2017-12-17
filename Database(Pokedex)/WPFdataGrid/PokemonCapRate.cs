using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PropertyChanged;

namespace WPFdataGrid
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    [Table(Name = "PokemonCapRates")]
    public class PokemonCapRate /*: PropertyValidateModel*/
    {
        [Required(ErrorMessage = "Pokemon name is required to save")]
        [StringLength(15, ErrorMessage = "Only 15 characters allowed in pokemon name")]
        [Column(IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never, CanBeNull = false)]
        [Key]
        public string PName { get; set; }
        [Column]
        [Range(0, Int16.MaxValue, ErrorMessage = "Not a valid positive number")]
        public Int16 CapRate { get; set; }
        [Column]
        [Range(0, Int16.MaxValue, ErrorMessage = "Not a valid positive number")]
        public Int16 ExpDrop { get; set; }

        public PokemonBaseStat PokemonBaseStat { get; set; }
    }

    //[PropertyChanged.AddINotifyPropertyChangedInterface]
    //public abstract class PropertyValidateModel : IDataErrorInfo
    //{
    //    public String Error { get => null; }

    //    public String this[string Column]
    //    {
    //        get
    //        {
    //            IList<ValidationResult> errors = new List<ValidationResult>();

    //            if (Validator.TryValidateProperty(GetType().GetProperty(Column).GetValue(this), new ValidationContext(this) { MemberName = Column }, errors))
    //            {
    //                return null;
    //            }

    //            return $"{errors[0].ErrorMessage}\n";
    //        }
    //    }
    //}
}
