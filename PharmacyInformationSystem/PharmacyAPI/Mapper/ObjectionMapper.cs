using PharmacyAPI.Dto;
using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Mapper
{
    public class ObjectionMapper
    {
        public Objection ObjectionDTOToObjection(ObjectionDto objectionDTO) {

            return new Objection(objectionDTO.Id, objectionDTO.TextObjection, objectionDTO.PharmacyName);

        }
    }
}
