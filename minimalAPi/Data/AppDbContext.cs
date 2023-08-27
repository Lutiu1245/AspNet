using Microsoft.EntityFrameworkCore;
namespace Todo{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todo.db;Cache=Shared");
        }
    }
}