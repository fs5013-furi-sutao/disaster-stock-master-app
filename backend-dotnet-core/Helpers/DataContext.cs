using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MstDisasterStock> MstDisasterStocks { get; set; }
        public DbSet<MstKbn> MstKbns { get; set; }
        public DbSet<MstProduct> MstProducts { get; set; }
        public DbSet<MstManufacture> MstManufactures { get; set; }
        public DbSet<MstPref> MstPrefs { get; set; }
        public DbSet<MstBranche> MstBranches { get; set; }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<MstProduct>(entity =>
        //     {
        //         entity.HasIndex(e => e.Cd).IsUnique();
        //     });
            
        //     builder.Entity<MstManufacrure>(entity =>
        //     {
        //         entity.HasIndex(e => e.Cd).IsUnique();
        //     });

        //     builder.Entity<MstPref>(entity =>
        //     {
        //         entity.HasIndex(e => e.Cd).IsUnique();
        //     });

        //     builder.Entity<MstBranche>(entity =>
        //     {
        //         entity.HasIndex(e => e.Cd).IsUnique();
        //     });


        //     base.OnModelCreating(builder);
        // }
    }
}