using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace 临时项目
{
    public class MyContext : DbContext
    {
        static MyContext context;

        public static MyContext GetContext()
        {
            if (context == null)
            {
                return new MyContext();
            }
            return context;
        }

        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// 博客
        /// </summary>
        public DbSet<Blog> Blog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=course;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(u =>
            //    u.HasIndex(m => m.Email).IsUnique()
            //);
            base.OnModelCreating(modelBuilder);
        }
    }
}