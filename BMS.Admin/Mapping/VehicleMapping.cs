using BMS.Domain.DTO.Parameters;
using BMS.Domain.Interfaces.DtoInterFace;
using BMS.DataLyar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMS.Domain.Mapping
{
   public partial class AutoMapperProfile
    {

        private void VehicleMapp()
        {
            CreateMap<IvehicleDTO, Vehicle>()
                .ForMember(des => des.ID, opt => opt.MapFrom(src => src.VehicleID))
                .ForMember(des => des.Code, opt => opt.MapFrom(src => src.VehicleCode))
                .ReverseMap();
            CreateMap<VehicleParameters, Vehicle>()
               .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.VehicleCode));

        }
    }
}
