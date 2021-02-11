﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MBRepoCore.Models_Example
{
    class SchoolContext:DbContext,IDbContextFactory<SchoolContext>
    {
        public SchoolContext()
        {
            
        } 
        public SchoolContext(DbContextOptions<SchoolContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        public SchoolContext GetInstance(IConfiguration configuration, string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new SchoolContext(optionsBuilder.Options);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Relace [MBARK\\MBARK_SERVER] by your server name
            //Relace [MySchoolDB] by your own/Suggested database name
            optionsBuilder.UseSqlServer("Server=MBARK-LAP;Database=MySchoolDB;Trusted_Connection=True;");

            //IConfiguration configuration = new ConfigurationBuilder()
            //                              .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            //                              .AddJsonFile("appsettings", false).Build();

            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("MBARKLap"));
        }

        public DbSet<Branche> Branches { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
