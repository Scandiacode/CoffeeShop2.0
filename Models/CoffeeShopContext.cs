using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop2.Models
{
    public class CoffeeShopContext : DbContext
    {
        public DbSet<CustomerModel> Customer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Server=.\sqlexpress;Database=CoffeeShopDb2;Integrated Security=SSPI;");

        }
    }
}
