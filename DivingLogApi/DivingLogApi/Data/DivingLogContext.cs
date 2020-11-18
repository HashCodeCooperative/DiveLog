using DivingLogApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Data
{
    public class DivingLogContext : DbContext
    {
        public DivingLogContext(DbContextOptions<DivingLogContext> options)
            : base(options)
        {
        }

        public DbSet<Dive> Dives { get; set; }
        public DbSet<DiveSite> DiveSites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDive> UserDives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Data/DivingLogDb.db");

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyContext>(modelBuilder);
        //    Database.SetInitializer(sqliteConnectionInitializer);
        //}
    }
}
