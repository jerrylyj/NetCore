using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySQL.Data.EntityFrameworkCore.Extensions;
using ShangBao.Model;
using System;
using System.Linq;

namespace ShangBao.Data
{
    public class DataContext : DbContext
    {

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseMySQL(@"Server=localhost;database=efcore;uid=root;pwd=root");

        
         public DbSet<User> Users { get; set; }
         public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var builder = new ConfigurationBuilder()
            //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //var configuration = builder.Build();

            //string connectionString = configuration.GetConnectionString("MySQLConnectionString");
            string connectionString = "Server=127.0.0.1;database=efcore;uid=root;pwd=root;";

            optionsBuilder.UseMySQL(connectionString);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   => optionsBuilder
        //       .UseMySql(@"Server=localhost;database=efcore;uid=root;pwd=root;");
        /// <summary>
        /// 配置属性和模型关系等操作
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<User>().HasMany(a => a.Products).WithOne(a => a.Owner);
 
         }
 
         /// <summary>
         /// 重写SaveChanges 方法，添加一些自定义操作
         /// </summary>
         /// <returns></returns>
         
 
         private void SetSystemProperty()
         {
             //查询模型添加和变更
             var modifiedSourceInfo = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();
 
             DateTime currentTime = DateTime.Now;
 
             //设置系统属性
             foreach (var entry in modifiedSourceInfo)
             {
                 entry.Property("CreateTime").CurrentValue = currentTime;
                 entry.Property("UpdateTime").CurrentValue = currentTime;
             }
             
 
         }
 
    }
}
