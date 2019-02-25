using AutoMapper;
using BMS.Admin.Apstraction;
using BMS.Admin.DTO;
using BMS.Admin.DTO.Parameters;
using BMS.Admin.Interfaces.BusinessInterface;
using BMS.DataLyar.Entities;
using BMS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Admin
{
    public class VehicleBusiness : BaseBusiness<Vehicle>, IVehicleBusiness
    {
        public VehicleBusiness(IUnitOfWork<Vehicle> unitOfWork, IMapper mapper):base(unitOfWork,mapper)
        {
                
        }

        public Task<bool> AddVehicle(VehicleParameters vehicleParameters)
        {
           
        }

        public Task<bool> DeleteVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllVehicle()
        {
                var getall=    _unitOfWork.repo.GetAll();
            
        }

        public Task<VehicleDTO> GetVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateVehicle(VehicleDTO vehicleDTO)
        {
            throw new NotImplementedException();
        }

        Task<IList<VehicleDTO>> IVehicleBusiness.GetAllVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
