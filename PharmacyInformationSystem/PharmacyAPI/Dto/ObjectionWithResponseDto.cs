using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class ObjectionWithResponseDto
    {
        public long Id { get; set; }
        public string HospitalName { get; set; }
        public string TextObjection { get; set; }
        public string TextResponse { get; set; }

        public ObjectionWithResponseDto() { }

        public ObjectionWithResponseDto(long id, string hospitalName, string textObjection, string textResponse)
        {
            this.Id = id;
            this.HospitalName = hospitalName;
            this.TextObjection = textObjection;
            this.TextResponse = textResponse;
        }


    }
}
