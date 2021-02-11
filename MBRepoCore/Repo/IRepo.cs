﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MBRepoCore.Repo
{
    interface IRepo<Tcontext> where  Tcontext : DbContext,IDbContextFactory<Tcontext>, new()
    {


        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;

        TEntity GetOne<TEntity>(object pkValue) where TEntity : class;

        void Insert<TEntity>(TEntity record) where TEntity : class;

        void InsertRange<TEntity>(List<TEntity> records) where TEntity : class;

        bool Contains<TEntity>(TEntity obj) where TEntity : class;

        bool Contains<TEntity, TEntityComparer>(TEntity obj)
            where TEntity : class
            where TEntityComparer : IEqualityComparer<TEntity>, new();

        void Delete<TEntity>(TEntity record) where TEntity : class;

        void Save();


    }
}
