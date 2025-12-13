using Microsoft.EntityFrameworkCore;

namespace CoreBase.Models
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=CoreBase;Uid=root;Pwd=;",
                new MySqlServerVersion(new Version(8, 0, 11)));
        }

        public DbSet<Manager> Users { get; set; }
    }
}
