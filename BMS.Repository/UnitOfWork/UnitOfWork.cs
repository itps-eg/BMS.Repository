using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BMS.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BMS.Repository.UnitOfWork
{
  public  class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private DbContext _context;
        private IDbContextTransaction _transaction;

        public IRepository<T> repo { get; }


        public UnitOfWork(DbContext context,IRepository<T> repository)
        {
            _context = context;
            repo = repository;
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
