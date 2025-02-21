using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class PixContext : DbContext
    {
        public PixContext()
        {

        }
        public PixContext (DbContextOptions options, IConfiguration _configuration):base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<StaticPix> StaticPix {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L921P76;Database=Estudo1;Trusted_Connection=True;Encrypt=false;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}