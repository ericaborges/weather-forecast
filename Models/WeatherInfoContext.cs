namespace WeatherForecast.Models
{
    using System.Data.Entity;

    public partial class WeatherInfoContext : DbContext
    {
        public WeatherInfoContext()
            : base("name=WeatherInfo")
        {
        }

        public virtual DbSet<Weather_info> Weather_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather_info>()
                .Property(e => e.main_temp)
                .HasPrecision(7, 3);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.main_temp_min)
                .HasPrecision(7, 3);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.main_temp_max)
                .HasPrecision(7, 3);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.main_pressure)
                .HasPrecision(8, 3);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.main_sea_level)
                .HasPrecision(8, 3);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.main_grnd_level)
                .HasPrecision(8, 3);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.main_temp_kf)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.weather_main)
                .IsUnicode(false);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.weather_description)
                .IsUnicode(false);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.weather_icon)
                .IsUnicode(false);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.wind_speed)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.wind_deg)
                .HasPrecision(7, 3);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.syspod)
                .IsUnicode(false);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.dt_txt)
                .IsUnicode(false);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.snow_3h)
                .HasPrecision(5, 3);

            modelBuilder.Entity<Weather_info>()
                .Property(e => e.rain_3h)
                .HasPrecision(5, 3);
        }
    }
}
