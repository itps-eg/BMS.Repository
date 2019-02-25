using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMS.Domain.Mapping
{
   public partial class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            VehicleMapp();
        }

    }
}
