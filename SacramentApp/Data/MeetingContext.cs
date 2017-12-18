using Microsoft.EntityFrameworkCore;
using SacramentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentApp.Data
{
    public class MeetingContext : DbContext
    {
        public MeetingContext(DbContextOptions<MeetingContext> options) : base(options)
        {
        }

        public DbSet<Hymn> Hymns { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Prayer> Prayers { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hymn>().ToTable("Hymn");
            modelBuilder.Entity<Speaker>().ToTable("Speaker");
            modelBuilder.Entity<Prayer>().ToTable("Prayer");
            modelBuilder.Entity<Meeting>().ToTable("Meeting");
        }
    }
}
