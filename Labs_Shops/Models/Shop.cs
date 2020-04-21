using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs_Shops.Models
{
    public partial class Shop
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Seller Seller { get; set; }
    }
}
