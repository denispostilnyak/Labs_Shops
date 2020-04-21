using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labs_Shops.Models
{
    public partial class Subcategory
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Only latina")]
        [Required(ErrorMessage = "The field should not be empty!")]
        [Display(Name = "Subcategory")]
        public string Name { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
