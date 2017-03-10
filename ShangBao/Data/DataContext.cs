using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using ShangBao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShangBao.Data
{
    public class DataContext : DbContext
    {
        //public DbSet<User> Users { set; get; }
        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseMySQL(@"Server=localhost;database=efcore;uid=root;pwd=root");

        public DataContext(DbContextOptions<DataContext> options)
             : base(options)
         { }
         public DbSet<User> User { get; set; }
         public DbSet<Product> Product { get; set; }
         //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         //{
         //}
 
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
         public override int SaveChanges()
         {
             ChangeTracker.DetectChanges();
 
             SetSystemProperty();
            
             return base.SaveChanges();
         }
 
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
