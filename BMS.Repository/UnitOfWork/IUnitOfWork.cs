using BMS.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Repository.UnitOfWork
{
   public interface IUnitOfWork<T>:IDisposable where T:class
    {
        IRepository<T> repo { get; }
        Task<int> SaveChanges();
    }
}
