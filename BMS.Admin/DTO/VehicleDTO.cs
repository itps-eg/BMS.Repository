using BMS.Domain.Interfaces.DtoInterFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMS.Domain.DTO
{
    public class VehicleDTO : IvehicleDTO
    {
        public int VehicleID { get; set; }
        public string VehicleCode { get ; set ; }
    }
}
