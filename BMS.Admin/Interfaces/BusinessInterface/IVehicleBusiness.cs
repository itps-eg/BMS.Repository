using BMS.Domain.DTO;
using BMS.Domain.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Domain.Interfaces.BusinessInterface
{
    public interface IVehicleBusiness
    {

        Task<IEnumerable<VehicleDTO>> GetAllVehicle();
        Task<VehicleDTO> GetVehicle(int id);
        Task<bool> AddVehicle(VehicleParameters vehicleParameters);
        Task<bool> UpdateVehicle(VehicleDTO vehicleDTO);
        Task<bool> DeleteVehicle(int id);
    }
}
