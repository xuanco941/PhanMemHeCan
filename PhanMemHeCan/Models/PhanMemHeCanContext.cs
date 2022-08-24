using Microsoft.EntityFrameworkCore;

namespace PhanMemHeCan.Models
{
    public class PhanMemHeCanContext : DbContext
    {
        public const string ConnectionString = @"Data Source=DESKTOP-P4IC2M8\SQLEXPRESS;Initial Catalog=PhanMemHeCan;User ID=sa;Password=942001xX";

        public DbSet<User.User> User { get; set; }
        public DbSet<Group.Group> Group { get; set; }
        public DbSet<Transport.Transport> Transport { get; set; }
        public DbSet<Car.Car> Car { get; set; }

        // Tạo ILoggerFactory 
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder
                   .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
                   .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information)
                   .AddConsole();
        }
        );

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(loggerFactory)  // - Thiết lập sử Logger
                .UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user
            modelBuilder.Entity<User.User>(entity =>
            {
                entity.Property(e => e.Password).HasDefaultValueSql("('leanway')");
                entity.HasIndex(e => e.Username).IsUnique();
            });

            //group
            modelBuilder.Entity<Group.Group>(entity =>
            {
                entity.Property(e => e.IsManagementGroup).HasDefaultValueSql("(0)");
                entity.Property(e => e.IsManagementUser).HasDefaultValueSql("(0)");
                entity.HasIndex(e => e.GroupName).IsUnique();

            });

            //transport
            modelBuilder.Entity<Transport.Transport>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
        }

        public static async Task ResetDatabase()
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            await phanMemHeCanContext.Database.EnsureDeletedAsync();
            await phanMemHeCanContext.Database.EnsureCreatedAsync();
        }
        
    }
}
