using AutoMapper;
using BMS.Admin.Apstraction;
using BMS.Admin.DTO;
using BMS.Admin.DTO.Parameters;
using BMS.Admin.Interfaces.BusinessInterface;
using BMS.Admin.Interfaces.DtoInterFace;
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

        public async Task<bool> AddVehicle(VehicleParameters vehicleParameters)
        {
            var veicle = Mapper.Map<VehicleParameters, Vehicle>(vehicleParameters);
            _unitOfWork.repo.Add(veicle);
            return await _unitOfWork.SaveChanges () > 0;
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            _unitOfWork.repo.Remove(x => x.ID == id);

            return await _unitOfWork.SaveChanges() > 0;
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllVehicle()
        {
                var getall= await _unitOfWork.repo.GetAll();
                var vehicleDTOs = Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleDTO>>(getall);
                return vehicleDTOs;
            
        }

        public async Task<VehicleDTO> GetVehicle(int id)
        {
            var vehicle = await _unitOfWork.repo.FirstOrDefault(wer => wer.ID == id);
            var vehicleDto = Mapper.Map<Vehicle, VehicleDTO>(vehicle);
            return vehicleDto;
        }

        public async Task<bool> UpdateVehicle(VehicleDTO vehicleDTO)
        {
            var vehicle = Mapper.Map<IvehicleDTO, Vehicle>(vehicleDTO);
            _unitOfWork.repo.Update(vehicle);
            return await _unitOfWork.SaveChanges() > 0;
        }

       
    }
}
