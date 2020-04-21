using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs_Shops.Models;
using Microsoft.EntityFrameworkCore;

namespace Labs_Shops
{
    public class Labs2_Context : DbContext
    {
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public Labs2_Context(DbContextOptions<Labs2_Context> options): base(options) {
            Database.EnsureCreated();
        }
    }
}
