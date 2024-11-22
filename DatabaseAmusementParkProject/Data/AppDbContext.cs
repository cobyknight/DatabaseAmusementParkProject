using Microsoft.EntityFrameworkCore;
using DatabaseAmusementParkProject.Entities;

namespace DatabaseAmusementParkProject.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<ThemePark> ThemeParks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ThemePark_Location> ThemeParks_Locations { get; set; }
        public DbSet<ThemePark_Reviews> ThemeParks_Review {  get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Favorites> User_Favorites { get; set; }
    }
}
