using Microsoft.EntityFrameworkCore;
using Ahmad.Assad.Domain;
using System;
using System.IO;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public string DbPath { get; }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "weather.db");
        }
    }
}