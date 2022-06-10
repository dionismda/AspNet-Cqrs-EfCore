using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(): base() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Server=host.docker.internal;Port=5432;Database=todo;User Id=postgres;Password=admin;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Todo");
            modelBuilder.Entity<Todo>().Property(x => x.Id);
            modelBuilder.Entity<Todo>().Property(x => x.User)
                                       .HasMaxLength(120)
                                       .HasColumnType("varchar(120)");
            modelBuilder.Entity<Todo>().Property(x => x.Title)
                                       .HasMaxLength(160)
                                       .HasColumnType("varchar(160)");
            modelBuilder.Entity<Todo>().Property(x => x.Done)
                                       .HasColumnType("bool");
            modelBuilder.Entity<Todo>().Property(x => x.Date);
            modelBuilder.Entity<Todo>().HasIndex(b => b.User);
        }

    }
}
