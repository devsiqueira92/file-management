using Microsoft.EntityFrameworkCore;


namespace FileManagement.Infrastructure.Context
{
    public class FileManagementContext : DbContext
    {
        public FileManagementContext(DbContextOptions<FileManagementContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is already configured on the Startup.cs
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //new ApplicationUserEntityTypeConfiguration().Configure(modelBuilder.Entity<ApplicationUser>());


        }

    }
}
