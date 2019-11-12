using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website_BanDienThoai_Version1.Models;

namespace Website_BanDienThoai_Version1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<SpecialTag> SpecialTag { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<ProductSelectedBill> ProductSelectedBill { get; set; }
    }
}
