using MeetingsAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MeetingsMembers>().HasKey(x => new { x.MemberId , x.MeetingId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MeetingsMembers> MeetingsMembers { get; set; }

    }
}
