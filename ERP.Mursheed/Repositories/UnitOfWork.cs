﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Mursheed.Utility;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public Dictionary<Type, object> Repositories
        {
            get { return _repositories; }
            set { Repositories = value; }
        }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(_dbContext);
            Repositories.Add(typeof(T), repo);
            return repo;
        }

        public async Task<TransResult<int>> Commit()
        {
            TransResult<int> transResult = new TransResult<int>() { IsSuccess = false };

            try
            {
                transResult.Object = await _dbContext.SaveChangesAsync();
                transResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                transResult.IsSuccess = false;
            }

            return transResult;

        }

        public void Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
