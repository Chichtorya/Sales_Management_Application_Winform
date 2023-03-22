using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



using Microsoft.EntityFrameworkCore.SqlServer;
using BusinessObject;

namespace DataAccess
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    

        private readonly string _connectionStrings;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasNoKey();
            // other configurations
        }
        public static IConfiguration Configuration { get; set; }
        public DbContext()
        {
         _connectionStrings = GetConnectionString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStrings);
        }
        public string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-9Q5VGFK\\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "sa";
            builder.InitialCatalog = "Fstore";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }
    }
}
