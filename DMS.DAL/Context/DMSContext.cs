using DMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.DAL.Context
{
    public class DMSContext : DbContext
    {
        public DbSet<UserFile> UserFiles { get; set; }

        public DMSContext(DbContextOptions<DMSContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFile>().ToTable("UserFile");
        }
    }
}
