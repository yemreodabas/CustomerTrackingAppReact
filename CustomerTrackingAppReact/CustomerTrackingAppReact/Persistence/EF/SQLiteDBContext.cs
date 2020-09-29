using CustomerTrackingAppReact.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Persistence.EF
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=C:\\Workspace\\github\\CustomerTrackingAppReact\\CustomerTrackingAppReact.sqlite");


    }
}
