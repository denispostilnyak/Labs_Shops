using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labs_Shops.Models
{
    public partial class Seller
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Only latina")]
        [Required(ErrorMessage = "The field should not be empty!")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field should not be empty!")]
        [Display(Name = "Adress")]
        public string Adress { get; set; }
        [Range(0, 10, ErrorMessage = "The value must be between 0 and 10")]
        [Required(ErrorMessage = "The field should not be empty!")]
        [Display(Name = "Rating")]
        public double Rating { get; set; }
        public virtual ICollection<Shop> Shop { get; set; }

    }
}
