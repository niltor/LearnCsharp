using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace database
{
    public class MyDatabase : DbContext
    {
        static MyDatabase database;

        public DbSet<User> User { get; set; }
        public DbSet<Blog> Blog { get; set; }


        public MyDatabase()
        {

        }
        internal static MyDatabase GetInstance()
        {
            if (database == null)
            {
                database = new MyDatabase();
            }
            return database;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=msdev;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
