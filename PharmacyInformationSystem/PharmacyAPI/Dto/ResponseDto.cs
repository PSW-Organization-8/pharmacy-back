using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class ResponseDto
    {
        public long Id { get; set; }
        public string ObjectionId { get; set; }
        public string TextResponse { get; set; }

        public ResponseDto() { }

        public ResponseDto(string text, string objectionId)
        {

            TextResponse = text;
            ObjectionId = objectionId;

        }
    }
}
