﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MBRepoCore.Factories
{
    static class RepoDBContextFactory

    {

        public static TContext GetInstance<TContext>(DbContextOptions options) where TContext:DbContext
        {
            TContext context = (TContext) Activator.CreateInstance(typeof(TContext), new object[] {options});
 
            return context;
        }
        
        public static TContext GetInstance<TContext>(string connectionString) where TContext:DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(connectionString);
            TContext context = (TContext) Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);
 
            return context;
        }

    }
}