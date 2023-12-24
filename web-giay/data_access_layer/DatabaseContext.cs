using Microsoft.EntityFrameworkCore;

namespace web_giay.business_logic_layer.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserStore> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<OrderStore> OrderStores { get; set; }
        public DbSet<SizeProduct> SizeProducts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            var builder = WebApplication.CreateBuilder();
            string conStr = builder.Configuration.GetConnectionString("MyConn");
            opt.UseSqlServer(conStr);

        }
    }
}
