using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Dto;
using PharmacyClassLib.Model;

namespace PharmacyAPI.Mapper
{
    public class RegisteredHospitalMapper
    {
        public static RegisteredHospital RegisteredHospitalDtoToRegisteredHospital(RegisteredHospitalDto dto)
        {
            return new RegisteredHospital(dto.Name, dto.Url, dto.ApiKey);
        }

        public static RegisteredHospitalDto RegisteredHospitalToRegisteredHospitalDto(
            RegisteredHospital rh)
        {
            return new RegisteredHospitalDto(rh.Name, rh.Url, rh.ApiKey);
        }
    }
}
