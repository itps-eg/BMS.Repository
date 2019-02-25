using AutoMapper;
using BMS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMS.Admin.Apstraction
{
  public  class BaseBusiness<T> where T :class 
    {
        public readonly IUnitOfWork<T> _unitOfWork;
        public readonly IMapper _Mapper;
        public BaseBusiness(IUnitOfWork<T> unitOfWork, IMapper Mapper)
        {
            _unitOfWork = unitOfWork;
            _Mapper = Mapper;

        }
    }
}
