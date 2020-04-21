using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labs_Shops.Models
{
    public partial class Category
    {
        public Category() {
            Subcategory = new HashSet<Subcategory>();
        }

        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Only latina")]
        [Required(ErrorMessage = "The field should not be empty!")]
        [Display(Name = "Category")]
        public string Name { get; set; }

        public virtual ICollection<Subcategory> Subcategory { get; set; }
    }
}
