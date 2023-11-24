using API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.EF
{
    public class HierarcyContext:DbContext
    {
        public DbSet<Folder> Folders { get; set; }
        public HierarcyContext(DbContextOptions<HierarcyContext> options)
            :base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-S7D9M3G\\SQLEXPRESS;Database=HierarcyDB;Integrated Security=true;TrustServerCertificate=true;");
        //}
    }
}
